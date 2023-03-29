import React, { useState } from 'react';

function EnterAdminMode(props) {
    const [size, setSize] = useState(25);
    const [licenseTable, setLicenseTable] = useState([]);

    const watchData = () => {
        fetch(`https://localhost:7292/api/Admin?size=${size}`,
            {
                "Content-Type": "application/json",
                mode: "cors"
            })
            .then(data => data.json())
            .then(data => {
                console.log(data);
                let dataArray = [];

                data.forEach(list => {
                    dataArray.push({
                        license: list["name"],
                        customer: list["rentCustomer"],
                        timeLeft: list["timeLeft"].toString()
                        })
                    }
                )
                console.log(dataArray);
                setLicenseTable(dataArray);
            }).catch(e => {
                console.log(e);
            });
    }
    return (
        <div className="App">
            <table>
                <tr>
                    <th>License</th>
                    <th>Customer</th>
                    <th>TimeLeft</th>
                </tr>
                {licenseTable.map((val, key) => {
                    return (
                        <tr key={key}>
                            <td>{val.license}</td>
                            <td>{val.customer}</td>
                            <td>{val.timeLeft}</td>
                        </tr>
                    )
                })}
            </table>
            <p>
                <button onClick={watchData}>Update Table</button>
            </p>
        </div>
    )
    
}
export default EnterAdminMode;