import React from "react"
import FeedbackForm from "./FeedbackForm"
import "../CSS/FeedbackForm.css"
import {
    BrowserRouter as Router,
    Switch,
    Route
  } from "react-router-dom";


class Main extends React.Component{

render(){

return(

    <Switch>


        <Route path="/sendfeedback">
            <FeedbackForm class="FeedbackFormStyling"/>
        </Route>


    </Switch>
)


}











}

export default Main