let furnitures = [];

function addFurniture() {
  let name = document.getElementById("furnitureName").value;
  let width = parseInt(document.getElementById("furnitureWidth").value);
  let height = parseInt(document.getElementById("furnitureHeight").value);

  if (name && !isNaN(width) && !isNaN(height)){
    furnitures.push({ name, width, height });
    updateFurnitureList();
  }
}