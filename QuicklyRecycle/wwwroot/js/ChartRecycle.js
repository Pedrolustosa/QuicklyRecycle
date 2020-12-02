new Chart(document.getElementById("line-chart"), {
    type: 'line',
    data: {
        labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set","Out","Nov","Dez"],
        datasets: [{
            label: "Reciclado",
            data: [12342, 32452, 76453, 45734, 54563, 34656, 34637, 34648, 34669, 12312, 34623, 23423],
            borderWidth: 3,
            borderColor: '#2ecc71',
            backgroundColor: "transparent",
        },
        {
            label: "Nâo Reciclados",
            data: [11230, 12452, 11231, 91234, 123518, 12346, 68903, 40875, 28962, 12312, 12354, 97750],
            borderWidth: 3,
            borderColor: '#e74c3c',
            backgroundColor: "transparent",
        },
        ]
    },
    options: {
        title: {
            display: true,
            fontSize: 12,
        },
        labels: {
            fontStyle: "bold"
        }
    }
});