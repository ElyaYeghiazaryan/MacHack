(function () {
	App.rest = App.rest || {};

	var rest = function (url, data) {
		return $.ajax({
			type: "GET",
			url: url,
			data: data,
			dataType: "json"
		})
	}


	App.rest.fetchAllBooks = function () {
		var url = siteRoot + 'Home/GetAllBooks';
		return rest(url);
	}

	App.rest.fetchBooks = function () {
		var url = siteRoot + 'Home/GetBooks';
		return rest(url);
	}

	App.rest.fetchBookData = function () {
		var url = siteRoot + 'Home/GetBookData';
		var data = {};
		return rest(url, {});
	}

	App.rest.fetchGenres = function () {
		var url = siteRoot + 'Home/GetGanres';
		return rest(url, {});
	}

	App.rest.fetchAllFilters = function () {
		var url = siteRoot + 'Home/GetFilters';
		return rest(url, {});
	}

	App.rest.fetchBook = function () {
		var url = siteRoot + 'Home/GetBookData';
		var bookId = 1;
		var data = { BookId: bookId };
		return rest(url, data);
	}



})();