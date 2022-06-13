$(function () {
    // Extract provided input from table row
    let extractData = function (tableName, row) {
        if (tableName === 'departmentTable' || tableName === 'skillTable')
            inputData = { 'name': row.find('.name').val(), 'isActive': row.find('.isActive').prop('checked') };
        else if (tableName === 'employeeTable')
            inputData = {
                'name': row.find('.name').val(),
                'email': row.find('.email').val(),
                'phone': row.find('.phone').val(),
                'departmentId': row.find('.departmentId').val(),
                'isActive': row.find('.isActive').prop('checked')
            };
        else if (tableName === 'employeeSkillTable')
            inputData = {
                'employeeId': row.find('.employeeId').val(),
                'skillId': row.find('.skillId').val()
            };
        return inputData;
    };

    // Toggle Read and Edit Modes in Table Row.
    let toggleModes = function (row) {
        row.find('.edit-mode').toggleClass('hide');
        row.find('.read-mode').toggleClass('hide');
    };

    // Add Button Click Action
    $(document).on('click', '.btnAdd', function () {
        var table = $(this).closest('table');
        var row = $(this).closest('tr');
        var tableName = table.attr('id');
        var inputData = {};

        inputData = extractData(tableName, row);

        $.ajax({
            url: '/Home/CreateEntity',
            method: 'POST',
            contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
            data: $.param({ 'entityJson': JSON.stringify(inputData), 'entityName': tableName.replace('Table', '') }),
            success: function (response) {
                console.log(response);
                if (response != null && response.data != null && response.data != 'Invalid Entity') {
                    $('#statusMessage').removeClass('text-danger').addClass('text-success').text("Data Added Successfully");
                    setTimeout(function () { window.location.reload(); }, 3000);
                }
                else
                    $('#statusMessage').removeClass('text-success').addClass('text-danger').text(response.data);
            },
            error: function (error) {
                $('#statusMessage').text(error);
            }
        });
    });

    // Edit Button Click Action
    $(document).on('click', '.btnEdit, .btnCancel', function () {
        var row = $(this).closest('tr');
        toggleModes(row);
    });

    // Edit Button Click Action
    $(document).on('click', '.btnSave', function () {
        var table = $(this).closest('table');
        var row = $(this).closest('tr');
        var tableName = table.attr('id');
        var inputData = {};

        inputData = extractData(tableName, row);
        inputData['id'] = row.attr('id');

        $.ajax({
            url: '/Home/UpdateEntity',
            method: 'PUT',
            contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
            data: $.param({ 'entityJson': JSON.stringify(inputData), 'entityName': tableName.replace('Table', '') }),
            success: function (response) {
                console.log(response);
                if (response != null && response.data != null && response.data != 'Invalid Entity') {
                    $('#statusMessage').removeClass('text-danger').addClass('text-success').text("Data Updated Successfully");
                    setTimeout(function () { window.location.reload(); }, 3000);
                }
                else
                    $('#statusMessage').removeClass('text-success').addClass('text-danger').text(response.data);
            },
            error: function (error) {
                $('#statusMessage').text(error);
            }
        });
    });

    // Delete Button Click Action
    $(document).on('click', '.btnDelete', function () {
        var table = $(this).closest('table');
        var row = $(this).closest('tr');
        var tableName = table.attr('id');
        var inputData = { 'id': row.attr('id') };

        $.ajax({
            url: '/Home/DeleteEntity',
            method: 'DELETE',
            contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
            data: $.param({ 'entityJson': JSON.stringify(inputData), 'entityName': tableName.replace('Table', '') }),
            success: function (response) {
                console.log(response);
                if (response != null && response.data != null && response.data != 'Invalid Entity') {
                    $('#statusMessage').removeClass('text-danger').addClass('text-success').text("Data Deleted Successfully");
                    row.remove();
                    setTimeout(function () { $('#statusMessage').text(''); }, 3000);
                }
                else
                    $('#statusMessage').removeClass('text-success').addClass('text-danger').text(response.data);
            },
            error: function (error) {
                $('#statusMessage').text(error);
            }
        });
    });
});