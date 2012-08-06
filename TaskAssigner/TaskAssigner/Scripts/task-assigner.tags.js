var AutoComplete = function (availableTags) {
    this.availableTags = availableTags;

    var split = function(val) {
        return val.split(/,\s*/);
    }
    
    var extractLast = function(term) {
        return split(term).pop();
    }
    
    $("#tags").autocomplete({
        source: function (request, response) {
            response($.ui.autocomplete.filter(availableTags, extractLast(request.term)));
        },
        select: function (event, ui) {
            var tags = this.value.split(/,\s*/);
            tags.pop();
            tags.push(ui.item.value);
            tags.push("");
            this.value = tags.join(", ");
            return false;
        }
    });
};