// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    let errorToast = document.getElementById('error-toast');
    if (!!errorToast) {
        let toastBlock = new bootstrap.Toast(errorToast);
        toastBlock.show();
    }

    let successToast = document.getElementById('success-toast');
    if (!!successToast) {
        let toastBlock = new bootstrap.Toast(successToast);
        toastBlock.show();
    }
})

let first = true;
$(document).ready(function () {
    if (first) {
        $("#addCategory").submit();
        first = false;
    }
    $('input[type=radio]').change(function () {
        if ($('#IsWithdrawl1').is(':checked')) {
            $('#isPositive').val($('#IsWithdrawl1').val());
            $("#addCategory").submit();
        }
        if ($('#IsWithdrawl2').is(':checked')) {
            $('#isPositive').val($('#IsWithdrawl2').val())
            $("#addCategory").submit();
        }
    });
});

function SetPlanner(e) {


    let plannerId = $('select#transactionPlan').val();
    let amountInput = $("#transactionAmount");
    let falseWithdrawlRadio = $("#IsWithdrawl1");
    let trueWithdrawlRadio = $("#IsWithdrawl2");
    if (plannerId) {
        let amountId = "#" + plannerId + "-transactionPlanAmout";
        let plannerAmount = $(amountId).val();
        amountInput.val(plannerAmount);
        amountInput.prop("readonly", true);

        let withdrawlId = "#" + plannerId + "-transactionPlanIsWithdrawl";
        let plannerWithdrawl = $(withdrawlId).val();
        if (plannerWithdrawl) {
            trueWithdrawlRadio.prop('checked', true);
            $('#isPositive').val($('#IsWithdrawl2').val());
            $("#addCategory").submit();
            falseWithdrawlRadio.prop('disabled', true);
        }
        else {
            falseWithdrawlRadio.prop('checked', true);
            $('#isPositive').val($('#IsWithdrawl1').val());
            $("#addCategory").submit();
            trueWithdrawlRadio.prop('disabled', true);
        }

    }
    else {
        amountInput.prop("readonly", false);
        trueWithdrawlRadio.prop('disabled', false);
        falseWithdrawlRadio.prop('disabled', false);
    }

}



function ShowDeleteModal(Id) {

    let input = $("#entityIdInput");
    console.log(input)
    input.val(Id);

    var thisModal = $("#delete-modal");
    thisModal.modal("show");

}
function ShowDetailsModal(Id) {

    let input = $("#bankAccountId");
    let input2 = $("#transactiontId");
    input.val(Id);
   
    input2.val(Id);

    let form = $("#addDetails");
    form.submit();
    let thisModal = $("#details-modal");
    thisModal.modal("show");

}
$('#addTransactionForm').on('reset', function (e) {
    console.log("hi");
    let amountInput = $("#transactionAmount");
    let falseWithdrawlRadio = $("#IsWithdrawl1");
    let trueWithdrawlRadio = $("#IsWithdrawl2");
    amountInput.prop("readonly", false);
    trueWithdrawlRadio.prop('disabled', false);
    falseWithdrawlRadio.prop('disabled', false);
});
$(".disabled").prop('disabled', true);