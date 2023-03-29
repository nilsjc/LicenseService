import React, { useState } from 'react';

function PushLicense(props) {
    const [inputValue, setInputValue] = useState("");

    const onChangeHandler = event => {
        setInputValue(event.target.value);
    };
    const insertLicense = () => {
        fetch(`https://localhost:7292/api/Admin?licenseName=${inputValue}`,
            {
                method: 'POST',
            }).catch(e => {
                console.log(e);
            })
    };
    return (
        <div className="Input">
            <p>
                <input type="text" onChange={onChangeHandler} value={inputValue }></input>
                <button onClick={insertLicense}>Insert License</button>
            </p>
        </div>
    )

}
export default PushLicense;