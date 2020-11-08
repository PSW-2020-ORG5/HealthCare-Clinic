import React from "react"
import "../CSS/Header.css"
import { Button } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.css';
import {
    Link,
    Switch,
    Route
  } from "react-router-dom";

class Header extends React.Component {

    render(){

        return(
            <div>
                <header className="App-Header">Some header value</header>

                <Button tag={Link} to="/sendfeedback"className="reactstrapButton" color="info">Send Feedback</Button>
                <Button tag={Link} to="/seefeedbacks"className="reactstrapButton" color="info">See feedbacks (user)</Button>
                <Button tag={Link} to="/feedbacks"className="reactstrapButton" color="info">See feedbacks (admin)</Button>
                
            </div>
        )
    }



}

export default Header