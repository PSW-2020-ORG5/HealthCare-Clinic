import React from "react"
import FeedbackForm from "./FeedbackForm"
import SeeFeedbacks from "./SeeFeedbacks"
import "../CSS/Feedbacks.css"

import {
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
        <Route path="/seefeedbacksadmin">
            <SeeFeedbacks role="admin" class="seeFeedbacksStyling" />
        </Route>
         <Route path="/seefeedbacksuser">
            <SeeFeedbacks role="user" class="seeFeedbacksStyling" />
        </Route> 
        
        


    </Switch>
)


}











}

export default Main