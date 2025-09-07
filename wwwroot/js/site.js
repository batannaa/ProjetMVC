// Logique pour le slider d'images
document.addEventListener('DOMContentLoaded', function () {
    let slideIndex = 0;
    let slides = document.querySelectorAll("#carouselExampleIndicators .carousel-item");
    function showSlides(n) {
        if (n >= slides.length) { slideIndex = 0; }
        if (n < 0) { slideIndex = slides.length - 1; }
        for (let i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slides[slideIndex].style.display = "block";
    }
    function plusSlides(n) {
        showSlides(slideIndex += n);
    }
    showSlides(slideIndex); 
    document.querySelector(".carousel-control-prev").addEventListener("click", function () { plusSlides(-1); });
    document.querySelector(".carousel-control-next").addEventListener("click", function () { plusSlides(1); });
    setInterval(function () { plusSlides(1); }, 3000);
});


// Validation des champs de formulaire
document.addEventListener('DOMContentLoaded', function () {
    let inputs = document.querySelectorAll('input');
    inputs.forEach(function (input) {
        input.addEventListener('blur', function (event) {
            let target = event.target;
            // Validation adresse courriel
            if (target.type === 'email') {
                if (isValidEmail(target.value.trim())) {
                    target.classList.add('valid');
                    target.classList.remove('invalid');
                } else {
                    target.classList.add('invalid');
                    target.classList.remove('valid');
                }
            } else {
                // Validation autres champs
                if (target.value.trim() !== '') {
                    target.classList.add('valid');
                    target.classList.remove('invalid');
                } else {
                    target.classList.add('invalid');
                    target.classList.remove('valid');
                }
            }
        });
    });
    function isValidEmail(email) {
        // Regex pour la validation du courriel
        // L'adresse doit contenir des lettres/chiffres, suivit de "@", puis des lettres/chiffres, suivit de ".", puis encore des lettres/chiffres.
        let regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return regex.test(email);
    }
});


// Validation des mots de passe
document.addEventListener('DOMContentLoaded', function () {
    let passwordField = document.getElementById('Password');
    let confirmPasswordField = document.getElementById('ConfirmPassword');
    passwordField.addEventListener('blur', validatePasswordFields);
    confirmPasswordField.addEventListener('blur', validatePasswordFields);
    function validatePasswordFields() {
        let password = passwordField.value.trim();
        let confirmPassword = confirmPasswordField.value.trim();

        if (password === confirmPassword && password !== '') {
            passwordField.classList.remove('invalid');
            passwordField.classList.add('valid');
            confirmPasswordField.classList.remove('invalid');
            confirmPasswordField.classList.add('valid');
        } else {
            passwordField.classList.remove('valid');
            passwordField.classList.add('invalid');
            confirmPasswordField.classList.remove('valid');
            confirmPasswordField.classList.add('invalid');
        }
    }
});


// Basculer le type de champ
function showPassword(inputId) {
    var input = document.getElementById(inputId);
    input.type = 'text';
}
function hidePassword(inputId) {
    var input = document.getElementById(inputId);
    input.type = 'password';
}


// Notification POP-UP de SweetAlert2 pour s'inscrire 
document.addEventListener('DOMContentLoaded', function () {
   
    if (registerSuccess) {
        alertRegisterMsg(); 
    }
});
function alertRegisterMsg() {
    Swal.fire({
        position: "center",
        icon: "success",
        title: "Votre compte a &eacute;t&eacute; cr&eacute;&eacute; avec succ&egrave;s",
        showConfirmButton: false,
        timer: 2000
    });
}


// Fonction pour démarrer l'animation du message de bienvenue
document.addEventListener("DOMContentLoaded", function () {
    // Vérifiez si l'utilisateur est authentifié
    const isAuthenticated = document.body.classList.contains('authenticated');

    // Récupérez l'indicateur d'animation (première connexion)
    const firstLogin = localStorage.getItem('firstLogin') === 'true';

    // Vérifiez si nous sommes sur la page d'accueil
    const isHomePage = window.location.pathname === '/' || window.location.pathname === '/index.html';

    if (isAuthenticated) {
        const greetingSteps = document.querySelectorAll(".greeting-step");
        const userNameStep = document.querySelector(".user-name");

        if (!firstLogin && isHomePage) {
            // Si l'utilisateur est connecté pour la première fois sur la page d'accueil
            let delay = 0;
            greetingSteps.forEach((step) => {
                setTimeout(() => {
                    step.classList.add("show");
                }, delay);
                delay += 500; 
            });

            // Marquer l'animation comme affichée après la première connexion
            localStorage.setItem('firstLogin', 'true');
        } else {
            // Si l'animation a déjà été affichée, ou si l'utilisateur revient sur la page d'accueil,
            // afficher seulement le nom sans animation
            greetingSteps.forEach((step) => {
                step.classList.remove("show");
                step.style.display = 'none';
            });
            userNameStep.classList.add("show");
            userNameStep.style.display = 'inline'; 
        }
    }
});
// Réinitialisation de l'indicateur lorsque l'utilisateur se déconnecte
document.querySelector('#logoutForm').addEventListener('submit', function () {
    localStorage.removeItem('firstLogin');
});



// Notification POP-UP de SweetAlert2 pour Ajout d'une borne
document.addEventListener('DOMContentLoaded', function () {
    // Gestion des messages d'erreur
    var errorMessageElement = document.getElementById('error-message');
    var errorMessage = errorMessageElement ? errorMessageElement.dataset.message : null;
    if (errorMessage) {
        showAlertError(errorMessage);
    }
    // Gestion des messages de succès
    var successMessageElement = document.getElementById('info-message');
    var successMessage = successMessageElement ? successMessageElement.dataset.message : null;
    if (successMessage) {
        showAlertSuccess(successMessage);
    }
});
function showAlertError(message) {
    Swal.fire({
        position: 'center',
        icon: 'error',
        title: message,
        showConfirmButton: false,
        timer: 2000,
        
    });
}
function showAlertSuccess(message) {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: message,
        showConfirmButton: false,
        timer: 2000,
        
    });
}


// Notification POP-UP de SweetAlert2 pour Ajout/Retrait d'une borne aux favoris 
document.addEventListener('DOMContentLoaded', function () {
    if (addBorneFavoriSuccess) {
        alertAddBorneFavoriMsg(addBorneFavoriMsg);
    }
    if (removeBorneFavoriSuccess) {
        alertRemoveBorneFavoriMsg(removeBorneFavoriMsg);
    }
});
function alertAddBorneFavoriMsg(message) {
    Swal.fire({
        position: "center",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 2000
    });
}
function alertRemoveBorneFavoriMsg(message) {
    Swal.fire({
        position: "center",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 2000
    });
}


// Générer les étoiles pour les notes et commentaires
document.addEventListener("DOMContentLoaded", function () {
    var starsElements = document.querySelectorAll(".stars");
    starsElements.forEach(function (starsDiv) {
        var note = parseInt(starsDiv.getAttribute("data-note")); 
        var totalStars = 5; 
        var stars = '';
        // Générer les étoiles pleines
        for (var i = 0; i < note; i++) {
            stars += '★';
        }
        // Générer les étoiles vides (s'il y a lieu)
        for (var j = note; j < totalStars; j++) {
            stars += '☆';
        }
        // Afficher les étoiles avec un espace
        starsDiv.innerHTML = stars + ' '; 
        // Ajouter les détails de la notation après les étoiles
        var ratingText = note.toFixed(1) + ' étoile(s) sur ' + totalStars;
        starsDiv.insertAdjacentHTML('beforeend', `<span>${ratingText}</span>`);
    });
});


// Notification POP-UP de SweetAlert2 pour Ajout d'un commentaire 
document.addEventListener('DOMContentLoaded', function () {
    const successMessage = document.getElementById('successMessage');
    if (successMessage) {
        alertAddCommentaireMsg(successMessage.innerText);
    }
});
function alertAddCommentaireMsg(message) {
    Swal.fire({
        position: "center",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 2000
    });
}


//gérer l'affichage des commentaires
$(document).ready(function () {
    $('#voir-plus-commentaires-link').on('click', function (event) {
        event.preventDefault();
        $('#commentsModal').modal('show');
    });
    $('.close, .btn-secondary').on('click', function () {
        $('#commentsModal').modal('hide');
    });
});


//afficher les messages d'erreur pour l'ajout d'un commentaire 
document.addEventListener('DOMContentLoaded', function () {
    // Vérifie si un message d'erreur est présent dans TempData
    var errorMessage = document.getElementById('error-message').dataset.message;
    if (errorMessage) {
        showAlertError(errorMessage);
    }
});
function showAlertError(message) {
    Swal.fire({
        position: 'center',
        icon: 'error',
        title: message,
        showConfirmButton: false,
        timer: 2000,

    });
}

//affichage de la pagination 
document.addEventListener("DOMContentLoaded", function () {
    const itemsPerPage = 5;
    const pageNumbersToShow = 4; 
    const table = document.querySelector('.table-borne tbody');
    const paginationContainer = document.getElementById('pagination');
    let currentPage = 1;
    let totalPages = Math.ceil(table.children.length / itemsPerPage);
    function renderPagination() {
        paginationContainer.innerHTML = '';

        const createButton = (text, page, className) => {
            const button = document.createElement('button');
            button.textContent = text;
            button.className = className;
            button.disabled = page < 1 || page > totalPages;
            button.addEventListener('click', () => goToPage(page));
            return button;
        };
        // Bouton pour aller à la première page
        paginationContainer.appendChild(createButton('««', 1, 'page first'));
        // Bouton pour aller à la page précédente
        paginationContainer.appendChild(createButton('« Précédent', currentPage - 1, 'page prev'));
        const startPage = Math.max(1, currentPage - Math.floor(pageNumbersToShow / 2));
        const endPage = Math.min(totalPages, startPage + pageNumbersToShow - 1);
        if (startPage > 1) {
            paginationContainer.appendChild(createButton('1', 1, 'page'));
            if (startPage > 2) {
                paginationContainer.appendChild(createButton('...', null, 'ellipsis'));
            }
        }
        for (let i = startPage; i <= endPage; i++) {
            const pageButton = createButton(i, i, i === currentPage ? 'page active' : 'page');
            paginationContainer.appendChild(pageButton);
        }
        if (endPage < totalPages) {
            if (endPage < totalPages - 1) {
                paginationContainer.appendChild(createButton('...', null, 'ellipsis'));
            }
            paginationContainer.appendChild(createButton(totalPages, totalPages, 'page'));
        }
        // Bouton pour aller à la page suivante
        paginationContainer.appendChild(createButton('Suivant »', currentPage + 1, 'page next'));
        // Bouton pour aller à la dernière page
        paginationContainer.appendChild(createButton('»»', totalPages, 'page last'));
    }
    function goToPage(page) {
        currentPage = page;
        updateTable();
        renderPagination();
    }
    function updateTable() {
        const rows = table.children;
        for (let i = 0; i < rows.length; i++) {
            rows[i].style.display = (i >= (currentPage - 1) * itemsPerPage && i < currentPage * itemsPerPage) ? '' : 'none';
        }
    }
    // Initialisation
    updateTable();
    renderPagination();
});



 // Méthode pour les boutons d’incrémentation et décrémentation pour les inputs de type texte (pour qu’il fonctionne comme un input de type number)
document.addEventListener('DOMContentLoaded', function () {
    // Sélecteurs pour NoteMinimale
    const noteInput = document.getElementById('noteMinimale');
    const increaseNoteBtn = document.getElementById('increaseBtn');
    const decreaseNoteBtn = document.getElementById('decreaseBtn');

    // Sélecteurs pour PuissanceMinimale
    const puissanceInput = document.getElementById('puissanceMinimale');
    const increasePuissanceBtn = document.getElementById('increasePuissanceBtn');
    const decreasePuissanceBtn = document.getElementById('decreasePuissanceBtn');

    // Définition des valeurs et pas pour NoteMinimale
    const noteMinValue = 1;
    const noteMaxValue = 5;
    const noteStep = 0.5;

    // Définition des valeurs et pas pour PuissanceMinimale
    const puissanceMinValue = 0;
    const puissanceMaxValue = 250;
    const puissanceStep = 10;

    function getValue(input, minValue, maxValue) {
        const value = parseFloat(input.value.replace(',', '.')) || minValue;
        return Math.min(Math.max(value, minValue), maxValue);
    }

    function setValue(input, value, isInteger) {
        if (isInteger) {
            input.value = Math.round(value).toString();
        } else {
            input.value = value.toFixed(1).replace('.', ',');
        }
    }

    function setupButtonHandlers(input, increaseBtn, decreaseBtn, minValue, maxValue, step, isInteger = false) {
        increaseBtn.addEventListener('click', function () {
            let currentValue = getValue(input, minValue, maxValue);
            if (currentValue < maxValue) {
                currentValue += step;
                if (currentValue > maxValue) currentValue = maxValue;
                setValue(input, currentValue, isInteger);
            }
        });

        decreaseBtn.addEventListener('click', function () {
            let currentValue = getValue(input, minValue, maxValue);
            if (currentValue > minValue) {
                currentValue -= step;
                if (currentValue < minValue) currentValue = minValue;
                setValue(input, currentValue, isInteger);
            }
        });

        input.addEventListener('input', function () {
            let currentValue = getValue(input, minValue, maxValue);
            if (currentValue !== parseFloat(input.value.replace(',', '.'))) {
                setValue(input, currentValue, isInteger);
            }
        });
    }

    // Initialisation des boutons pour NoteMinimale
    setupButtonHandlers(noteInput, increaseNoteBtn, decreaseNoteBtn, noteMinValue, noteMaxValue, noteStep);

    // Initialisation des boutons pour PuissanceMinimale
    setupButtonHandlers(puissanceInput, increasePuissanceBtn, decreasePuissanceBtn, puissanceMinValue, puissanceMaxValue, puissanceStep, true); // true pour afficher sans décimales
});













