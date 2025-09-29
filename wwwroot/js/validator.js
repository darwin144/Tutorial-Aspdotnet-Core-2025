

function triggerBtn() {
    swal({
        title: "Konfirmasi",
        message: "Anda Yakin?",
        icon: "warning",
        buttons: {
            cancel: {
                name: "Cancel",
                visible:true,
                className: "btn-danger",
                closeModal: true
            },
            Confirm: {
                name: "Ok",
                value: true,
                visible: true,
                className: "btn-primary"
            }
        }
    }).then(result => {
        if (result) {
            document.getElementById("BtnSubmit").classList.remove("disabled");

            const triggerBtn = document.getElementById("BtnTrigger");
            triggerBtn.classList.add("disabled");
            triggerBtn.classList.remove("btn-secondary");
            triggerBtn.classList.add("disabled");
            triggerBtn.classList.add("btn-outline-secondary");


            
        }
        else {
            console.log("Dibatalkan")

        }
    })
}

function validateMandatoryFields(formSelector) {
    let form = document.querySelector(formSelector);
    let isValid = true;

    form.querySelectorAll(".error-message").forEach(el => el.remove());
    form.querySelectorAll(".input-error").forEach(el => el.classList.remove("input-error"));

    form.querySelectorAll("[data-required='true']").forEach(input => {
        if (!input.value.trim()) {
            isValid = false;

            // Tambah class merah pada input
            input.classList.add("input-error");
            let fieldName = input.getAttribute("data_name") || "Field";
            // Buat pesan error
            let errorMsg = document.createElement("div");
            errorMsg.classList.add("error-message");
            errorMsg.innerText = `${fieldName} tidak boleh kosong! `;

            // Sisipkan pesan di bawah input
            input.insertAdjacentElement("afterend", errorMsg);
        }
    });

    return isValid;
}


function submitForm() {
    if (!validateMandatoryFields("#FormOne")) {
        return false;
    };

    var urlController ="../Home/SubmitForm/"
    $.ajax({
        url: urlController,
        type: "POST",
        data: $("#FormOne").serialize(),
        success: function (response) {
            alert("Berhasil");
        },
        error: function (xhr, status, error) {
            alert("Gagal menghubungi server");
        }
    });
    return false; // mencegah form submit default
}