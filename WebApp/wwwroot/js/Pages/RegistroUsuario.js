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
            await Swal.fire('Error', 'Las contraseñas no coinciden.', 'error');
            return;
        }

        // 1. Enviar OTPs
        try {
            await Promise.all([
                fetch(`/api/Cliente/SendEmailVerification?email=${encodeURIComponent(email)}`),
                fetch(`/api/Cliente/SendSmsVerification?telefono=${encodeURIComponent(phone)}`)
            ]);
        } catch (err) {
            await Swal.fire('Error', 'Error al enviar códigos OTP.', 'error');
            return;
        }

        // 2. Pedir códigos al usuario con Swal inputs
        const { value: emailCode } = await Swal.fire({
            title: 'Código de verificación',
            input: 'text',
            inputLabel: 'Ingresa el código que recibiste por correo',
            inputValidator: value => !value && 'Debes ingresar el código'
        });

        if (!emailCode) return;

        const { value: smsCode } = await Swal.fire({
            title: 'Código de verificación',
            input: 'text',
            inputLabel: 'Ingresa el código que recibiste por SMS',
            inputValidator: value => !value && 'Debes ingresar el código'
        });

        if (!smsCode) return;

        // 3. Verificar códigos
        try {
            const otpResp = await fetch(`/api/Otp/Verify?email=${encodeURIComponent(email)}&telefono=${encodeURIComponent(phone)}&emailCode=${emailCode}&smsCode=${smsCode}`);
            const otpData = await otpResp.json();
            if (!otpResp.ok || !otpData.success) {
                await Swal.fire('Error', 'Códigos incorrectos.', 'error');
                return;
            }
        } catch {
            await Swal.fire('Error', 'Error verificando códigos.', 'error');
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
            await Swal.fire('Error', 'Error en verificación facial.', 'error');
            return;
        }

        await Swal.fire(
            facialPassed ? 'Verificación aprobada' : 'Verificación fallida',
            facialPassed ? 'La verificación facial fue exitosa.' : 'La verificación facial falló.',
            facialPassed ? 'success' : 'error'
        );
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

            await Swal.fire('Éxito', 'Cuenta creada con éxito.', 'success');
            window.location.href = "/index.html";
        } catch {
            await Swal.fire('Error', 'No se pudo crear la cuenta.', 'error');
        }
    });
});
