const url = "http://localhost:5048/api/room/furnishing";
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



async function FurnishRoom() {  
  let data ={
    roomWidth: parseInt(document.getElementById("roomWidth").value),
    roomHeight: parseInt(document.getElementById("roomHeight").value),
    furnitures: furnitures
  }

  const response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  });

  if (response.status == 400) {
    alert('Hibás bemenet!')
  }
  else if (response.status == 200){
      const res = await response.json();
      const matrix = res.space;
      DrawRoom(matrix)
  }
}



function DrawRoom(matrix) {
  const table = document.getElementById('roomTarget')
  table.innerHTML = "";
  table.style.borderCollapse = "collapse";

  let size = 50/parseInt(document.getElementById("roomWidth").value); 
  console.log(size);
   
  
  for (let row = 0; row < matrix.length; row++) {
    for (let col = 0; col < matrix[row].length; col++) {
      if (!matrix[row][col]) {
        matrix[row][col] = {
          width: 1,
          height: 1,
          name: "",
          drawn: false
        }
      }
    }
  }

  for (let i = 0; i < matrix.length; i++) {
    let row = document.createElement("tr");
    row.style.height = `${size}vw`
    table.appendChild(row);

    for (let j = 0; j < matrix[i].length; j++) {
      let furniture = matrix[i][j];
      
      if (!furniture.drawn){
        let td = document.createElement("td");
        tdSize = GetFurnitureSize(matrix, i, j);
        td.style.width = `${tdSize.width * size}vw`;
        td.style.maxWidth = `${tdSize.width * size}vw`;
        td.style.height = `${tdSize.height * size}vw`;
        td.style.maxHeight = `${tdSize.height * size}vw`;
        td.colSpan = `${tdSize.width}`
        td.rowSpan = `${tdSize.height}`
        td.innerHTML = matrix[i][j].name
        signDrawnCells(matrix, tdSize, i, j);
        if (furniture.name != "") {
          td.classList.add("filledCell")
        }
        row.appendChild(td);
      }
    }
  }
}

function GetFurnitureSize(matrix, row, col){
  let name = matrix[row][col].name
  let size = {width: 1, height: 1}
  while (row + size.height < matrix.length && matrix[row + size.height][col].name == name && !matrix[row + size.height][col].drawn) {
    size.height += 1;
  }
  while (col + size.width < matrix[row].length && matrix[row][col + size.width].name == name && !matrix[row][col + size.width].drawn) {
    size.width += 1;
  }
  console.log(size);
  
  return size;
}

function signDrawnCells(matrix, tdSize, row, col){
  for (let i = 0; i < tdSize.height; i++) {
    for (let j = 0; j < tdSize.width; j++) {
      matrix[row + i][col + j].drawn = true;
    }
  }
}