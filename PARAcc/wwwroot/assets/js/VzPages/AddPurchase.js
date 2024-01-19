var selectedOption = 1;
function openProdModal() {
    $('#exampleModalScrollable').modal('show');
    loadData();
}
$(document).ready(function () {

    var storedData = localStorage.getItem('PurchaseTable');
    if (storedData) {
        $('.PurchPopBody').html(storedData);
    }
    $('#exampleModalScrollable').on('shown.bs.modal', function () {
        openProdModal();
        $('.PurchPopBody').on('click', '.purchpoptb', function () {
            var prodCode = $(this).find('.prodCodeColumn').text();
            fetchProdData(prodCode);
        });
        $('#searchBox').on('keyup', function () {
            loadData();
        });

        $('#searchSelect').on('change', function () {
            selectedOption = $(this).val();
            loadData();
        });
    });
});

function loadData() {
    var searchText = $('#searchBox').val() || '';

    var url = '/Purchase/PopProdTablePartial';
    url += '?selectedOption=' + selectedOption + '&searchText=' + searchText;
    $.ajax({
        url: url,
        method: 'GET',
        success: function (partialView) {
            $('.PurchPopBody').html(partialView);
        },
        error: function (error) {
            console.error('Error loading partial view PopProdTablePartial:', error);
        }
    });
}
function fetchProdData(prodCode) {
    $.ajax({
        url: '/Purchase/FetchProd?ProdCode=' + prodCode,
        method: 'GET',
        success: function (data) {
            updateFormWithData(data);

        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}
function updateFormWithData(data) {
    $('.AddPurchaseForm').html(data);
    //localStorage.setItem('PurchaseTable',data.AddPurchaseForm);
    $('#exampleModalScrollable').modal('hide');
    //$('.PurchaseTable').html(data.PurchaseTable);
}