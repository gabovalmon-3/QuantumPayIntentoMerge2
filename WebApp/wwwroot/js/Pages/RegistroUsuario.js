document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("create-account-form");
    const userTypeSelect = document.getElementById("UserType");

    form.addEventListener("submit", async function (e) {
        e.preventDefault();

        // Obtén el tipo de usuario
        const userType = userTypeSelect.value;

        // Construye el objeto de datos según el tipo de usuario
        let data = {};
        let apiUrl = "";

        if (userType === "Cliente") {
            data = {
                nombre: form.querySelector('[name="SignUpRequest.Nombre"]').value,
                apellido: form.querySelector('[name="SignUpRequest.Apellido"]').value,
                cedula: form.querySelector('[name="SignUpRequest.Cedula"]').value,
                telefono: parseInt(form.querySelector('[name="SignUpRequest.Telefono"]').value),
                correo: form.querySelector('[name="SignUpRequest.Correo"]').value,
                direccion: form.querySelector('[name="SignUpRequest.Direccion"]').value,
                contrasena: form.querySelector('[name="SignUpRequest.Password"]').value,
                IBAN: form.querySelector('[name="SignUpRequest.IBAN"]').value,
                // Si quieres enviar imágenes como base64:
                fotoCedula: "", // Puedes agregar lógica para convertir el archivo a base64
                fotoPerfil: "",
                fechaNacimiento: form.querySelector('[name="SignUpRequest.FechaNacimiento"]').value
            };
            apiUrl = "https://localhost:5001/api/Cliente/Create";
        } else if (userType === "Admin") {
            data = {
                nombreUsuario: form.querySelector('[name="SignUpRequest.NombreUsuario"]').value,
                contrasena: form.querySelector('[name="SignUpRequest.Password"]').value
            };
            apiUrl = "https://localhost:5001/api/Admin/Create";
        } else if (userType === "CuentaComercio") {
            data = {
                nombreUsuario: form.querySelector('[name="SignUpRequest.NombreUsuario"]').value,
                contrasena: form.querySelector('[name="SignUpRequest.Password"]').value,
                cedulaJuridica: form.querySelector('[name="SignUpRequest.CedulaJuridica"]').value,
                telefono: parseInt(form.querySelector('[name="SignUpRequest.Telefono"]').value),
                correoElectronico: form.querySelector('[name="SignUpRequest.CorreoElectronico"]').value,
                direccion: form.querySelector('[name="SignUpRequest.Direccion"]').value
            };
            apiUrl = "https://localhost:5001/api/CuentaComercio/Create";
        } else if (userType === "InstitucionBancaria") {
            data = {
                codigoIdentidad: form.querySelector('[name="SignUpRequest.CodigoIdentidad"]').value,
                codigoIBAN: form.querySelector('[name="SignUpRequest.CodigoIBAN"]').value,
                cedulaJuridica: form.querySelector('[name="SignUpRequest.CedulaJuridica"]').value,
                direccionSedePrincipal: form.querySelector('[name="SignUpRequest.DireccionSedePrincipal"]').value,
                telefono: parseInt(form.querySelector('[name="SignUpRequest.Telefono"]').value),
                correoElectronico: form.querySelector('[name="SignUpRequest.CorreoElectronico"]').value
            };
            apiUrl = "https://localhost:5001/api/InstitucionBancaria/Create";
        } else {
            alert("Seleccione un tipo de usuario válido.");
            return;
        }

        // Enviar datos al API
        try {
            const response = await fetch(apiUrl, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                alert("Registro exitoso. Ahora puede iniciar sesión.");
                window.location.href = "/Login";
            } else {
                const error = await response.text();
                alert("Error al registrar el usuario: " + error);
            }
        } catch (err) {
            alert("Error de red o del servidor.");
        }
    });

    const allFields = document.querySelectorAll(".user-fields");

    function showFieldsForType(type) {
        allFields.forEach(f => f.style.display = "none");
        if (!type) return;
        const className = "user-" + type.toLowerCase();
        const fields = document.querySelectorAll("." + className);
        fields.forEach(f => f.style.display = "block");
    }

    userTypeSelect.addEventListener("change", function () {
        showFieldsForType(this.value);
    });

    // Mostrar campos correctos si hay valor preseleccionado (por ejemplo, en validación fallida)
    showFieldsForType(userTypeSelect.value);
});
