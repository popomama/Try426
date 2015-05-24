$(function () {

    var CreateAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-book-autocomplete"),
    //        messages: {
    //        noResults: '',
    //        results: function() {}
    //}

        };

        $input.autocomplete(options);

    }
    $("input[data-book-autocomplete]").each(CreateAutocomplete);

});

$(function () {
    $("#autoSearchForm #autoSubmit").mouseover(function () {
        $(this).animate({ height: '+=25', width: '+=25' })
               .animate({ height: '-=25', width: '-=25' });
    });
});