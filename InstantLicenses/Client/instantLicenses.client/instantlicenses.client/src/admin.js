import React, { useState } from 'react';

function EnterAdminMode(props) {
    const [size, setSize] = useState(25);
    const [licenseTable, setLicenseTable] = useState([{ name: "Anom", age: 19, gender: "Male" }]);

    const watchData = () => {
        fetch(`https://localhost:7292/api/Admin?size=${size}`,
            {
                "Content-Type": "application/json",
                mode: "cors"
            })
            .then(data => data.json())
            .then(data => {
                licenseTable = data;
            }).catch(e => {
                console.log(e);
            });
    }
    return (
        <div className="App">
            <p>
                <button onClick={watchData}>Update Table</button>
            </p>
            <table>
                <tr>
                    <th>License</th>
                    <th>Customer</th>
                    <th>TimeLeft</th>
                </tr>
                {licenseTable.map((val, key) => {
                    return (
                        <tr key={key}>
                            <td>{val.name}</td>
                            <td>{val.age}</td>
                            <td>{val.gender}</td>
                        </tr>
                    )
                })}
            </table>
        </div>
    )
    
}
export default EnterAdminMode;