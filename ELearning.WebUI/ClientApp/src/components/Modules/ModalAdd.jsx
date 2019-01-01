import React, { Component } from 'react';
import { Button, Header, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAdd.scss';

class ModalAdd extends Component {
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
                console.log(error);
            })
    }
    render() {



        return (
            <Modal trigger={<Button>Dodaj zadanie</Button>} centered={false}>
                <Modal.Header>Dodaj zadanie</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Tytuł zadania</Header>
                        <Input className='exerciseInput' placeholder='tytuł zadania' onChange={this.handleChange} />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAdd
