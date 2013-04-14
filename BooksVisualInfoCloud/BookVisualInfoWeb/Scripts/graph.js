(function () {

	sigma.publicPrototype.circularLayout = function (clusters) {
		var r = 0.080;


		this.iterNodes(function (n) {
			var k = _.find(all_nodes, function (node) {
				return node.id === n.id;
			})
			var x0 = k.cluster_center.x;
			var y0 = k.cluster_center.y;
			var maxX = x0 + r;
			var minX = x0 - r;
			var x = Math.random() * (maxX - minX) + minX;

			var maxY = y0 + r;
			var minY = y0 - r;
			var y = Math.random() * (maxY - minY) + minY;

			n.x = x;
			n.y = y;
			n.color = k.color;

		});

		return this.position(0, 0, 1).draw();
	};

	var graph_container = document.getElementById('graph_container');
	var sigInst = sigma.init(graph_container).drawingProperties({
		defaultLabelColor: '#fff'
	});

	App.sigma = {};
	App.sigma.s = sigInst;


	var clusters = [],
        books = [],
        all_nodes = [];

	App.sigma.clusters = clusters;

	App.sigma.init = function () {
		for (i = 0; i < books.length; i++) {
			var book = books[i];

			sigInst.addNode(book.id, {
				'x': Math.random(),
				'y': Math.random(),
				'size': 0.5 + 4.5 * Math.random(),
				'color': 'rgb(' + Math.round(Math.random() * 256) + ',' +
                          Math.round(Math.random() * 256) + ',' +
                          Math.round(Math.random() * 256) + ')',
				'label': book.title


			});
			sigInst.draw();


		}
	}

	App.sigma.combineInClusters = function (key) {
		var filter_ids = []; var i = 0;
		_.each(books, function (book) {
			var filter_id = book[key]; // genre_id value

			if (!_.contains(filter_ids, filter_id)) {
				filter_ids.push(filter_id);

				var color = 'rgb(' + Math.round(Math.random() * 256) + ',' +
                          Math.round(Math.random() * 256) + ',' +
                          Math.round(Math.random() * 256) + ')'
				var cluster = {
					'id': filter_id,
					'nodes': [book.id],
					'color': color,
					'coord_x': Math.random(),
					'coord_y': Math.random()
				};

				clusters.push(cluster);

				var node = sigInst.getNodes(book.id);
				//node.cluster = cluster.id;
				//node.color = cluster.color;

				all_nodes.push({ id: node.id, cluster_center: {
					x: cluster.coord_x,
					y: cluster.coord_y
				}, color: cluster.color
				});

			} else {
				var cluster = _.find(clusters, function (c) {
					return c.id === filter_id;
				});

				cluster.nodes.push(book.id);

				var node = sigInst.getNodes(book.id);
				//node.cluster = cluster.id;
				//node.color = cluster.color;

				all_nodes.push({ id: node.id, cluster_center: {
					x: cluster.coord_x,
					y: cluster.coord_y
				}, color: cluster.color
				});
			}
		});

		sigInst.circularLayout(all_nodes);
	}


	/*********************************************************/
	/*
	App.sigma.setup = function() {
	for (i = 0; i < books.length; i++) {
	var book = books[i];

	sigInst.addNode(book.id,{
	'x': Math.random(),
	'y': Math.random(),
	'size': 0.5+4.5*Math.random(),
	'color': 'rgb('+Math.round(Math.random()*256)+','+
	Math.round(Math.random()*256)+','+
	Math.round(Math.random()*256)+')',
	'label': book.title
	});
	sigInst.draw();
	}

	App.sigma.clust("genre_id")
	}

	App.sigma.clust = function(key) {
	var filter_ids = []; var i = 0;
	_.each(books, function(book) {
	var filter_id = book[key]; // genre_id value
            
	if (!_.contains(filter_ids, filter_id)) {
	filter_ids.push(filter_id);

	var color = 'rgb('+Math.round(Math.random()*256)+','+
	Math.round(Math.random()*256)+','+
	Math.round(Math.random()*256)+')'
	var cluster = {
	'id': filter_id,
	'nodes': [book.id],
	'color': color,
	'coord_x':  Math.random(),
	'coord_y':  Math.random()
	};
                
	clusters.push(cluster);

	var node = sigInst.getNodes(book.id);
	//node.cluster = cluster.id;
	//node.color = cluster.color;
	node.color = "black";
	sigInst.position(0,0,0).draw(4,4,4);
	//sigInst.draw()
                
	} else {
	var cluster = _.find(clusters, function(c) {
	return c.id === filter_id;
	});

	cluster.nodes.push(book.id);

	var node = sigInst.getNodes(book.id);
                
	//node.cluster = cluster.id;
	//node.color = cluster.color;
	node.color = "black";
	sigInst.position(0,0,0).draw(2,2,2);

	//sigInst.draw();
                
	}
	});
        
	sigInst.position(0,0,0).draw(2,2,2);
        
	sigInst.iterNodes(function(n) {
	console.log(n);
	});

	}
	*/
	/******************************************************/

	var promise = App.rest.fetchAllBooks();
	promise.done(function (data) {
		books = data;
		App.sigma.init();
	});
})();    