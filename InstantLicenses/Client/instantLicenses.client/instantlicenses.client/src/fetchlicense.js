import React, { useState } from 'react';

function FetchLicense(props) {
    const [name, setName] = React.useState(props.name);
    const [licenseName, setLicenseName] = React.useState("");

    const rentClick =() =>{
        fetch(`https://localhost:7292/api/Customer/${name}`,
            {
                "Content-Type": "application/json",
                mode: "cors"
            })
            .then(data => data.json())
            .then(data => {
                console.log(data["name"]);
                let statusBit = data["status"];
                if (statusBit == 1) {
                    setLicenseName(`You got license ${data["name"]}`)
                } else {
                    setLicenseName(`You already have license ${data["name"]}`)
                }
            }).catch(e => {
                console.log(e);
            });
    }

    return (
        <p>
            <button onClick={rentClick}>Get license {name}</button>
            {licenseName}
        </p>
    );
}

export default FetchLicense;