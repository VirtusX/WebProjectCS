var pass;
$(function () {
    $('#pass1').on('input focus', function () {
        pass = $('#pass2');
        if ($(this).val().length > 0 && pass.val().length > 0) {
            if ($(this).val() != pass.val()) {
                $(this).addClass('wrong').removeClass('ok');
                pass.addClass('wrong').removeClass('ok');
            }
            else {
                $(this).addClass('ok').removeClass('wrong');
                pass.addClass('ok').removeClass('wrong');
            }
        }
    })
});
$(function () {
    $('#pass2').on('input focus', function () {
        pass = $('#pass1');
        if ($(this).val().length > 0 && pass.val().length > 0) {
            if ($(this).val() != pass.val()) {
                $(this).addClass('wrong').removeClass('ok');
                pass.addClass('wrong').removeClass('ok');
            }
            else {
                $(this).addClass('ok').removeClass('wrong');
                pass.addClass('ok').removeClass('wrong');
            }
        }
    })
});

$(function () {
    $('#pass1,#pass2').blur(function () {
        $('#pass2').removeClass('ok').removeClass('wrong');
        $('#pass1').removeClass('ok').removeClass('wrong');
    })
});
