document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("create-account-form");

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        // Validar campos principales
        const fullname = document.getElementById("fullname").value.trim();
        const identification = document.getElementById("identification").value.trim();
        const phone = "+506" + document.getElementById("phone").value.trim();
        const email = document.getElementById("email").value.trim();
        const password = document.getElementById("password").value.trim();
        const confirmPassword = document.getElementById("confirm-password").value.trim();
        const selfie = document.getElementById("selfie").files[0];
        const cedula = document.getElementById("cedula").files[0];

        if (password !== confirmPassword) {
            alert("Las contraseñas no coinciden.");
            return;
        }

        // 1. Enviar OTPs
        try {
            await Promise.all([
                fetch(`/api/Otp/SendEmail?email=${encodeURIComponent(email)}`),
                fetch(`/api/Otp/SendSms?telefono=${encodeURIComponent(phone)}`)
            ]);
        } catch (err) {
            alert("Error al enviar códigos OTP.");
            return;
        }

        // 2. Pedir códigos al usuario
        const emailCode = prompt("Ingresa el código que recibiste por correo:");
        const smsCode = prompt("Ingresa el código que recibiste por SMS:");
        if (!emailCode || !smsCode) {
            alert("Debes ingresar ambos códigos.");
            return;
        }

        // 3. Verificar códigos
        try {
            const otpResp = await fetch(`/api/Otp/Verify?email=${encodeURIComponent(email)}&telefono=${encodeURIComponent(phone)}&emailCode=${emailCode}&smsCode=${smsCode}`);
            const otpData = await otpResp.json();
            if (!otpResp.ok || !otpData.success) {
                alert("Códigos incorrectos.");
                return;
            }
        } catch {
            alert("Error verificando códigos.");
            return;
        }

        // 4. Verificación facial
        let facialPassed = false;
        try {
            const formData = new FormData();
            formData.append("selfie", selfie);
            formData.append("cedula", cedula);
            const facialResp = await fetch("/api/Verificacion/Facial", {
                method: "POST",
                body: formData
            });
            const facialData = await facialResp.json();
            facialPassed = facialData.aprobado;
        } catch {
            alert("Error en verificación facial.");
            return;
        }

        alert(facialPassed ? "Verificación facial aprobada." : "Verificación facial fallida.");
        if (!facialPassed) return;

        // 5. Crear cuenta
        try {
            const data = {
                nombre: fullname,
                cedula: identification,
                telefono: phone,
                correo: email,
                contrasena: password
            };
            const createResp = await fetch(`/api/Cliente/Create?emailCode=${emailCode}&smsCode=${smsCode}`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data)
            });
            if (!createResp.ok) throw new Error();

            alert("Cuenta creada con éxito.");
            window.location.href = "/index.html";
        } catch {
            alert("No se pudo crear la cuenta.");
        }
    });
});
