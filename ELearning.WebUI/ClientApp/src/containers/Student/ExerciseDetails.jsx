import React, { Component } from 'react';
import { Header, Button, Container } from 'semantic-ui-react';
import axios from '../../axios';

import './ExerciseDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import OpenNewWindow from '../../components/Modules/OpenNewWindow';

class ExerciseDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            assigmnentDetails: null,
            showComponent: false,
        }
        this._onButtonClick = this._onButtonClick.bind(this);
        this._onClose = this._onClose.bind(this);
    }
    loadData = () => {


        axios.get('/api/Assignments/GetById/' + this.props.match.params.previousAssignmentID)
            .then(response => {
                console.log("AssignmentDetails",response.data  )
                this.setState({ assigmnentDetails: response.data });
            }).catch(error => {
                console.log(error.response);
            })

    }

    componentDidMount = () => {
        this.loadData();
    }
    _onButtonClick = () => {
        this.setState({ showComponent: true });

    }
    _onClose = () => {
        this.setState({ showComponent: false });
    }

    render() {

        return (
            <div className='exerciseContainer'>
                <div className="doneExerciseCode">

                    {this.state.assigmnentDetails ?
                        <Header size='large'>{this.state.assigmnentDetails.exercisetitle}</Header>
                        : null}
                    {this.state.assigmnentDetails ?
                        <CodeWindow changeMode={true} code={this.state.assigmnentDetails.solution} />
                        : null}
                </div>
                <div className='exerciseInfo'>
                    {this.state.assigmnentDetails ?
                        <Header size='large'>Data:&nbsp;{this.state.assigmnentDetails.date}</Header>
                        : null}
                    <Button onClick={this._onButtonClick}>Treść</Button>

                    {this.state.showComponent ?
                        <OpenNewWindow close={this._onClose} htmlCode={this.state.assigmnentDetails.content} />
                        : null
                    }
                    {this.state.assigmnentDetails ?
                        <Container className='gradeContainer'> Ocena:&nbsp;{this.state.assigmnentDetails.finalgrade}</Container>
                        : null}
                </div>
            </div>
        );
    }
}

export default ExerciseDetails;