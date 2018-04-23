$(document).ready(function () {
    $('.custom-file-input').on('change', function () {
        var fileName = $(this).val();
        $(this).next('.custom-file-label').html(fileName);
        var ext = $(this).val().match(/\.(.+)$/)[1];
        switch (ext) {
            case 'jpg':
            case 'jpeg':
            case 'png':
            case 'gif':
                $('#file-hint').removeClass('text-danger');
                $('#file-hint').addClass('text-info');
                $('#file-hint').html("Format checked.");
                break;
            default:
                //$(this).val("");
                $('#file-hint').removeClass('text-info');
                $('#file-hint').addClass('text-danger');
                $('#file-hint').html("This is not an allowed file type.");
        }
    });
});