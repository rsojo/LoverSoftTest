//Variables
const carrito = document.querySelector('#carrito');
const listaCursos = document.querySelector('#lista-cursos');
const contenedorCarrito = document.querySelector('#lista-carrito tbody');
const vaciarCarritoBtn = document.querySelector('#vaciar-carrito');
const terminarCompraBtn = document.querySelector('#terminar-compra');
let articulosCarrito = [];

//Listeners *****
cargarEventListeners();


function cargarEventListeners() {
    //Cuando agregas un curso presionando 'Agregar al carrito'
    listaCursos.addEventListener('click', agregarCurso);
    //Elimina cursos del carrito
    carrito.addEventListener("click", eliminarCurso);

    //muestra los cursos del storage
    document.addEventListener('DOMContentLoaded', () => {
        //recuerda si no hay productos en el carrito se agrega un array vácio para que no de error.
        articulosCarrito = JSON.parse(localStorage.getItem("carrito")) || [];
        carritoHTML();
    })
    //Vaciar carrito
    vaciarCarritoBtn.addEventListener("click", () => {
        articulosCarrito = articulosCarrito.values = [];
        localStorage.removeItem("carrito");
        limpiarHTML();

        document.querySelector('#TotalCart').textContent = "";
    });
    terminarCompraBtn.addEventListener("click", () => {


        // Send the articulosCarrito to the backend
        fetch('Home/Purchase', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(articulosCarrito.map(curso => ({ Quantity: curso.cantidad, EncryptedProductId: curso.id })))
        }).then(data => {
           
            if (data.status == 200) {
                
                vaciarCarritoBtn.click();
                window.location.href = 'Home/Purchase';
            } else {
                alert('Error al realizar la compra');
            }
        });
    });
}

// Funciones ****************************************

function agregarCurso(e) {
    e.preventDefault();
    // Delegation para agregar-carrito
    if (e.target.classList.contains('agregar-carrito')) {

        const curso = e.target.parentElement.parentElement;
        // Enviamos el curso seleccionado para tomar sus datos
        console.log(curso);
        leerDatosCurso(curso);
        productoAgregado(curso);
    }
}
function productoAgregado(curso) {
    //Crear una alerta
    const alert = document.createElement("H4");
    alert.style.cssText = "background-color: red; color: white; text-align: center;";
    alert.style.margin = "5px 20px";
    alert.textContent = 'Añadido al carrito'
    curso.appendChild(alert);
    setTimeout(() => {
        alert.remove();
    }, 2000);
}

function eliminarCurso(e) {
    if (e.target.classList.contains('borrar-curso')) {
        const cursoId = e.target.getAttribute("data-id");

        //Elimina del arreglo por el data-id
        articulosCarrito = articulosCarrito.filter(curso => curso.id !== cursoId);
        carritoHTML();
    }
}

//Lee el contenido del HTML al que le dimos click y extrae la información del curso.
function leerDatosCurso(curso) {
    console.log(curso);
    //Crear un objeto con el contenido del curso actual
    const infoCurso = {
        imagen: curso.querySelector('img').src,
        titulo: curso.querySelector('h4').textContent,
        precio: curso.querySelector('.precio span').textContent,
        id: curso.querySelector('a').getAttribute('data-id'),
        cantidad: 1
    }
    //Revisa si un elemento ya existe en el carrito
    const existe = articulosCarrito.some(curso => curso.id === infoCurso.id);
    if (existe) {
        //Creamos una copia del arreglo
        const cursos = articulosCarrito.map(curso => {

            if (curso.id === infoCurso.id) {
                curso.cantidad++;
                return curso; // este retorna el objeto actualizado
            } else {
                return curso;// retorna los que no son duplicados
            }
        });
        articulosCarrito = [...cursos];

    } else {
        articulosCarrito = [...articulosCarrito, infoCurso];
    }

    //Agregar elementos al carrito  
    carritoHTML();
}


// Muestra el carrito de compras en el HTML
function carritoHTML() {

    limpiarHTML();
    var totalCart = 0;
    articulosCarrito.forEach(curso => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>  
                <img src="${curso.imagen}" width=100>
            </td>
            <td>${curso.titulo}</td>
            <td>${curso.precio}</td>
            <td>${curso.cantidad} </td>
            <td>
                <a href="#" class="borrar-curso" data-id="${curso.id}">X</a>
            </td>
        `;
        totalCart += parseFloat(curso.precio.replace("$", "")) * curso.cantidad;
        contenedorCarrito.appendChild(row);

    });
    const totalCartElement = document.querySelector('#TotalCart');
    if (totalCartElement) {
        if (totalCart > 200) {
            totalCart -= totalCart * 0.05;
            totalCartElement.textContent = "(-5%) $" + totalCart;
        } else {
            totalCartElement.textContent = "$" + totalCart;
        }
    }
    //Agregar el carrito de compras al storage
    sincronizarStorage();

}
function sincronizarStorage() {
    localStorage.setItem("carrito", JSON.stringify(articulosCarrito));
}
// Elimina los cursos del tbody
function limpiarHTML() {
    //forma lenta
    //:contenedorCarrito.innerHTML = '';
    while (contenedorCarrito.firstChild) {
        contenedorCarrito.removeChild(contenedorCarrito.firstChild)
    }
}

