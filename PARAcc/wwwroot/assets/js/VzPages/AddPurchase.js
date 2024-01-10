function openDropdown() {
    // Fetch data from the server
    $.ajax({
        url: '/API/GetAddPurchaseProd',
        type: 'GET',
        success: function (data) {
            // Build and display the dropdown content
            buildDropdownContent(data);
            $('#dropdownContent').show();
        }
    });
}

function buildDropdownContent(data) {
    // Build the HTML table based on the data
    var tableHtml = '<table>';
    // Add header row
    tableHtml += '<tr><th>ID</th><th>Name</th></tr>';

    // Add data rows
    $.each(data, function (index, item) {
        tableHtml += '<tr><td>' + item.Id + '</td><td>' + item.Name + '</td></tr>';
        // Add more cells as needed based on your model
    });

    tableHtml += '</table>';

    // Set the HTML content of the dropdown
    $('#dropdownContent').html(tableHtml);
}
