import React from "react"
import "../CSS/Header.css"
import { Link,BrowserRouter } from 'react-router-dom';

class Header extends React.Component {

    render(){

        return(
            <div>
            <header className="App-Header">Some header value</header>
                <span className="input-group-btn">
                <BrowserRouter>
                <Link to="/routebookmark" >Click to login</Link>
                </BrowserRouter>
                </span>
            </div>
        )
    }



}

export default Header