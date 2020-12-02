new Chart(document.getElementById("pie-chart"), {
    type: 'pie',
    data: {
        labels: ["Papel", "Plástico", "Vidro", "Metal", "Madeira", "Res. Perigoso",
            "Hospitalar", "Radioativo", "Orgânicos", "Não Reciclavel"],
        datasets: [{
            backgroundColor: ["#3498db", "#e74c3c", "#2ecc71", "#f1c40f", "#2c3e50", "#e67e22",
                "#ecf0f1", "#8e44ad", "#964b00", "#95afc0"],
            data: [2478, 5267, 734, 123, 4134, 231, 1234, 123, 1234, 1242]
        }]
    },
    options: {
        title: {
            display: true,
        }
    }
});