let getButton = document.getElementById("btn1")


let port = "7256";
let url = 'https://localhost:${port}/api/users';

let getAllUsers = async () => {
    let response = await (url);
    let data = await response.json();

    console.log(data);
}

getButton.addEventListener("click", getAllUsers);