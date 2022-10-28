function fnLoadChildDDl(PrimaryDDL, ChildDDl, SelectMsg, URL)
{
    var PrimaryDDLPK = $('#' + PrimaryDDL).val();

    $('#' + ChildDDl).html('<option>' + SelectMsg + '</option>');

    $.getJSON(URL, { PKtoPass: PrimaryDDLPK }, function (data) {
        $.each(data, function (key, value) {
            var option = $('<option></option>').attr('value', value.id).text(value.name);
            $('#' + ChildDDl).append(option);
        });
    });
}

function fnLoadChildDDlSelected(PrimaryDDL, ChildDDl, SelectMsg, URL, hdnCtrl)
{
    var PrimaryDDLPK = $('#' + PrimaryDDL).val();
    var ChildIdtoSelect = $('#' + hdnCtrl).val();

    $('#' + ChildDDl).html('<option>' + SelectMsg + '</option>');

    $.getJSON(URL, { PKtoPass: PrimaryDDLPK }, function (data) {

        $.each(data, function (key, value) {
            var option = $('<option></option>').attr('value', value.id).text(value.name);
            if (value.id == ChildIdtoSelect) {
                option.prop('selected', true);
            }

            $('#' + ChildDDl).append(option);
        });
    });
}