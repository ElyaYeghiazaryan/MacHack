(function() {
	App.rest = App.rest || {};

	var rest = function(url, data) {
		return $.ajax({
  			type: "GET",
  			url: url,
  			data: data || {},
  			dataType: "json"
		})
	}

	App.rest.fetchBooks = function() {
		return rest("bubble_data.json");
	}

})();