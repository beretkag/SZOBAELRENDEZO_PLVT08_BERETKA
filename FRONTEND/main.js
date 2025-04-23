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

function updateFurnitureList() {
  let list = document.getElementById("furnitureList");
  list.style.listStyleType = "none"
  list.innerHTML = "";
  furnitures.forEach((f, i) => {
    let li = document.createElement("li");
    let item = document.createElement("span")
    item.textContent = `${f.name} (${f.width}x${f.height})`;
    const btn = document.createElement("button");
    btn.innerHTML = `<i class="bi bi-trash3-fill"></i>`;
    btn.className = "btn btn-sm text-danger";
    btn.onclick = () => {
      furnitures.splice(i, 1);
      updateFurnitureList();
    };
    li.appendChild(btn);
    li.appendChild(item)
    list.appendChild(li);
  });
}