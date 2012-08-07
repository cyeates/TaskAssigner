var AutoComplete = (function () {

    var split = function (val) {
        return val.split(/,\s*/);
    };

    var extractLast = function (term) {
        return split(term).pop();
    };

    var initAutoComplete = function (availableTags) {
        $("#tags")
            //prevents text box from loosing focus when you hit tab
            .bind("keydown", function (event) {
                if (event.keyCode === $.ui.keyCode.TAB &&
                        $(this).data("autocomplete").menu.active) {
                    event.preventDefault();
                }
            })
            .autocomplete({
                source: function(request, response) {
                    response($.ui.autocomplete.filter(availableTags, extractLast(request.term)));
                },
                select: function(event, ui) {
                    var tags = this.value.split( /,\s*/ );
                    tags.pop();
                    tags.push(ui.item.value);
                    tags.push("");
                    this.value = tags.join(", ");
                    return false;
                },
                focus: function() {
					//prevents textbox from value when hitting enter to select a tag
					return false;
				}
            });
    };

    $.get("/Tags/GetTags", function (result) {
        initAutoComplete(result);
    });




} ());