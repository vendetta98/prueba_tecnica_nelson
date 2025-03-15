import axios from "axios";
import { useEffect, useState } from "react";

function Empleados() {
    const [empleados, setEmpleados] = useState(null);

    useEffect(() => {
        axios.get("http://localhost:5113/api/tienda/empleados").then((response) => {
            setEmpleados(response.data)
            console.log(response.data);
        });
    }, []);

    if(!empleados) return null;

  return (
    <div>
        <h2>Datos Empleados:</h2>
        {empleados.map((x) => (
            <div>
                <p>Nombre:{x.nombre} - Correo:{x.correo} - Dui:{x.dui} Numero Tienda: {x.idTienda}</p>
            </div>
        ))}
    </div>
  )
}

export default Empleados;