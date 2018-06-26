
$("#submit").click(function () {
	
	let season = $("#season_select").val();
	let gameMode = $("#queue-select").val();
	$.ajax({
		url: '/Home/GetSeason',
		data: { "season": season},
		success: function (result) {
			console.log(result);
			renderStats(result, gameMode);
		},
		error: function (e) {
			console.log(e);
			alert("Something went wrong!");
		}
	});

});




function renderStats(result, gameMode) {

	let json = JSON.parse(result);
	let stats = json.data.attributes.gameModeStats[gameMode];
	let node = document.getElementById("myChart");

	while (node.firstChild) {
		myNode.removeChild(myNode.firstChild);
	}


	let ctx = document.getElementById("myChart").getContext('2d');
	let myChart = new Chart(ctx, {
		type: 'bar',
		data: {
			labels: ["Rounds played", "Top 10s", "Wins"],
			datasets: [{
				label: 'Statistics ' + gameMode,
				data: [stats.roundsPlayed, stats.top10s, stats.wins],
				backgroundColor: [
					'rgba(255, 99, 132, 0.2)',
					'rgba(54, 162, 235, 0.2)',
					'rgba(255, 206, 86, 0.2)',
					'rgba(75, 192, 192, 0.2)',
					'rgba(153, 102, 255, 0.2)',
					'rgba(255, 159, 64, 0.2)'
				],
				borderColor: [
					'rgba(255,99,132,1)',
					'rgba(54, 162, 235, 1)',
					'rgba(255, 206, 86, 1)',
					'rgba(75, 192, 192, 1)',
					'rgba(153, 102, 255, 1)',
					'rgba(255, 159, 64, 1)'
				],
				borderWidth: 2
			}]
		},
		options: {
			scales: {
				yAxes: [{
					ticks: {
						beginAtZero: true
					}
				}]
			}
		}
	});
}