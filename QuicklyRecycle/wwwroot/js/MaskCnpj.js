var maskCnpj = IMask(document.getElementById('cnpj'), {
    mask: [
        {
            mask: '00.000.000/0000-00',
            maxLength: 14
        }
    ]
});