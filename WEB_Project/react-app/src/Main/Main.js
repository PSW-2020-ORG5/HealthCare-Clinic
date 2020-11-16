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
        <Route path="/seefeedbacks">
            <SeeFeedbacks />
        </Route>
         <Route path="/seefeedbackspublished">
            <SeeFeedbacks onlyPublished="true"/>
        </Route> 
        
        


    </Switch>
)


}











}

export default Main