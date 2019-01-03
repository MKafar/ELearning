import React, { Component } from 'react';
import { Button, Header, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddExercise.scss';


class ModalAddExercise extends Component {

    constructor(props) {
        super(props);
    };

    state = {
        title: ''
    }

    handleChange = (e) => {
        this.setState({ title: e.target.value })
    }
    addHandle = () => {
        const inputData = this.state.title;
        axios.post('/api/Exercises/Create', {
            title: inputData
        })
            .then(response => {
                console.log(response);
            })
            .catch(error => {
                console.log(error.response);
            })
    }
    render() {



        return (
            <Modal closeIcon trigger={<Button primary className='addExercisebutton'>Dodaj zadanie</Button>} centered={false}>
                <Modal.Header>Dodaj zadanie</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Tytuł zadania</Header>
                        <Input className='exerciseInput' placeholder='tytuł zadania' onChange={this.handleChange} />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData();}}> Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddExercise
