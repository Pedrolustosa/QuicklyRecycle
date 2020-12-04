new Chart(document.getElementById("pie-chart"), {
    type: 'pie',
    data: {
        labels: ["Papel", "Plástico", "Vidro", "Metal", "Madeira", "Res. Perigoso",
            "Hospitalar", "Radioativo", "Orgânicos", "Não Reciclavel"],
        datasets: [{
            backgroundColor: ["#3498db", "#e74c3c", "#2ecc71", "#f1c40f", "#2c3e50", "#e67e22",
                "#ecf0f1", "#8e44ad", "#964b00", "#95afc0"],
            data: [478, 267, 734, 123, 134, 231, 234, 123, 234, 242]
        }]
    },
    options: {
        title: {
            display: true,
        }
    }
});