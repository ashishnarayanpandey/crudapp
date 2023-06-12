$(document).ready(function () {
    $('#ChooesImg').change(function (e) {
        var url = $('#ChooesImg').val();
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (ChooesImg.files && ChooesImg.files[0] && (ext == "gif" || ext == "jpg" || ext == "png" || ext=="bmb")) {
            var reader = new FileReader();
            reader.onload = function () {
                var output = document.getElementById('PrevImg');
                output.src = reader.result;
            }
            reader.readAsDataURL(e.target.files[0]);
        }

    });

});