// Personnalisation des icônes
var iconNACS = L.icon({
    iconUrl: '/Images/pinpoint_nacs.png',
    iconSize: [32, 32],
    iconAnchor: [16, 32],
    popupAnchor: [0, -32]  //
});

var iconJ1772 = L.icon({
    iconUrl: '/Images/pinpoint_j1772.png',
    iconSize: [32, 32],
    iconAnchor: [16, 32],
    popupAnchor: [0, -32]
});

document.addEventListener("DOMContentLoaded", function () {
    // Pour initialiser la carte et définir le centre avec le niveau de zoom
    var map = L.map('map').setView([46.8139, -71.2082], 7); // Coordonnées de la ville de Québec

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Pour récupérer les données des bornes à partir des attributs data-
    var bornesData = document.getElementById("borneData").dataset.bornes;
    console.log("Données des bornes récupérées:", bornesData);

    try {
        var bornes = JSON.parse(bornesData);
        console.log("Données des bornes analysées:", bornes);

        // Pour ajouter des marqueurs
        bornes.forEach(function (borne) {
            if (borne.latitude && borne.longitude) {
                var icon;
                // Pour sélectionner l'icône en fonction du type de connecteur
                if (borne.typeConnecteur === "NACS") {
                    icon = iconNACS;
                } else if (borne.typeConnecteur === "J1772") {
                    icon = iconJ1772;
                } else {
                    icon = L.icon({
                        iconUrl: '/images/pinpoint_default.png',
                        iconSize: [32, 32],
                        iconAnchor: [16, 32],
                        popupAnchor: [0, -32]
                    });
                }

                L.marker([borne.latitude, borne.longitude], { icon: icon }).addTo(map)
                    .bindPopup('<b>' + borne.typeConnecteur + '</b><br />' + borne.puissanceKW + ' kW<br />' + borne.adresse);
                console.log("Marqueur ajouté pour la borne:", borne);
            } else {
                console.warn("Coordonnées invalides pour la borne:", borne);
            }
        });
    } catch (e) {
        console.error("Erreur lors de l'analyse des données des bornes:", e);
    }
});

