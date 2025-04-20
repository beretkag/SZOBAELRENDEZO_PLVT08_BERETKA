const url = "http://localhost:5048/api/room/furnishing";

const dummy_payload = {
  roomWidth: 10,
  roomHeight: 10,
  furnitures: [
    { Name: "Ágy", Width: 3, Height: 2 },
    { Name: "Asztal", Width: 5, Height: 6 }
  ]
};

fetch(url, {
  method: "POST",
  headers: {
    "Content-Type": "application/json"
  },
  body: JSON.stringify(dummy_payload)
})
.then(res => res.json())
.then(room => console.log(room.space))