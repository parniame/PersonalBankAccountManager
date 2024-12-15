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


