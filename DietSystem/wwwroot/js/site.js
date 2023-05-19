// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var foodCounter = 0; // Лічильник для генерації унікальних id страв

// Додавання страви
document.getElementById('meal-plan').addEventListener('click', function (event) {
	if (event.target.classList.contains('add-food')) {
		var meal = event.target.parentNode;
		var foodContainer = meal.querySelector('.food');
		var newFood = foodContainer.cloneNode(true);
		var newId = 'food-' + foodCounter++; // генерація унікального id
		newFood.id = newId;
		foodContainer.parentNode.insertBefore(newFood, event.target);
	}
});
// Видалення страви
document.getElementById('meal-plan').addEventListener('click', function (event) {
	if (event.target.classList.contains('remove-food')) {
		var food = event.target.parentNode;
		food.parentNode.removeChild(food);
	}
});