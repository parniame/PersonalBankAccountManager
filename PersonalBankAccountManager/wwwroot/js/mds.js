$(document).ready(function () {
    if ($("#date-text").length) {
        let value = '2023/05/01';
        if ($("#DateOfBirth").val() != "") {
            value = $("#DateOfBirth").val();

        }
        const dtp1Instance = new mds.MdsPersianDateTimePicker(document.querySelector('#date-text'), {
            targetTextSelector: '#date-text',
            targetDateSelector: '#DateOfBirth',
            selectedDate: new Date(value),
            selectedDateToShow: new Date(value),
        });
    }
    if ($("#date-min").length) {
        const dtp1Instance2 = new mds.MdsPersianDateTimePicker(document.querySelector('#date-min'), {
            targetTextSelector: '#date-min',
            targetDateSelector: '#from',

            enableTimePicker: true,
            textFormat: 'yyyy/MM/dd HH:mm',
            dateFormat: 'yyyy/MM/dd HH:mm'
        });
    }
    if ($("#date-max").length) {
        const dtp1Instance2 = new mds.MdsPersianDateTimePicker(document.querySelector('#date-max'), {
            targetTextSelector: '#date-max',
            targetDateSelector: '#to',
            enableTimePicker: true,
            textFormat: 'yyyy/MM/dd HH:mm',
            dateFormat: 'yyyy/MM/dd HH:mm'
        });
    }
    if ($("#date-planner").length) {
        let value = '2023/05/01';
        if ($("#TillThisDate").val() != "") {
            value = $("#TillThisDate").val();

        }
        const dtp1Instance2 = new mds.MdsPersianDateTimePicker(document.querySelector('#date-planner'), {
            targetTextSelector: '#date-planner',
            targetDateSelector: '#TillThisDate',
            enableTimePicker: true,
            textFormat: 'yyyy/MM/dd HH:mm',
            dateFormat: 'yyyy/MM/dd HH:mm',
            selectedDate: new Date(value),
            selectedDateToShow: new Date(value),
        });
    }
});