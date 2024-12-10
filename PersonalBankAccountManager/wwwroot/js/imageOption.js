var i = setInterval(
    function () {
        $("#trace")
            .val($("input[name=bankId]:checked")
                .val());
        $("#trace")
            .val($("input[name=BankAccountId]:checked")
                .val());
    }
    , 100);
$(document).ready(function () {
    var list = $('.image-dropdown > input[type=radio]');
    list[0].checked = true;
    
});

