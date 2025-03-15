import axios from "axios";
import { useEffect, useState } from "react";

function Datos() {
    const [data, setData] = useState(null);

    useEffect(() => {
        axios.get("http://localhost:5113/api/tienda").then((response) => {
            setData(response.data)
            console.log(response.data);
        });
    }, []);

    if(!data) return null;

  return (
    <div>
        <h1>Datos de tienda</h1>
        {data.map((z) => (
            <div>
                <p>Tienda: {z.nombreTienda} - Numero Empleado: {z.idEmpleado}</p>
            </div>
        ))}
    </div>
  )
}

export default Datos