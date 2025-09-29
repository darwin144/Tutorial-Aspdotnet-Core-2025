
function openModal(vmType) {
    spinner
    $('#modalBody').html('<div class="text-center p-3"><div class="spinner-border text-primary" role="status"></div></div>');
    $('#modalLabel').text(`Form ${vmType}`);

    $.ajax({
        url: `./User/GetPartial`,
        method: 'GET',
        data: { vm: vmType },
        success: function (html) {
            $('#modalBody').html(html);
            $('#modalLabel').text(`Form ${vmType}`);
            const modal = new bootstrap.Modal(document.getElementById('dynamicModal'));
            modal.show();
        },
        error: function (xhr, status, error) {
            console.error("Gagal memuat partial view:", error);
            alert("Terjadi kesalahan saat memuat form.");
        }
    });   
}