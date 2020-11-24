import React from "react"
import "../CSS/Header.css"
import { Button } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom";
import logo from './cliniclogo.jpg'

class Header extends React.Component {

    render(){

        return(
            <div>
                <span className="App-Header">
                    <header >Health Clinic</header>
                    <img src={logo} width="70" height="50" alt=""/>
                </span>

                <Button tag={Link} to="/sendfeedback"className="reactstrapButton" color="info">Send Feedback</Button>
                <Button tag={Link} to="/seefeedbacks"className="reactstrapButton" color="info">See feedbacks</Button>
                <Button tag={Link} to="/seefeedbackspublished"className="reactstrapButton" color="info">See published feedbacks </Button>
                
            </div>
        )
    }



}

export default Header