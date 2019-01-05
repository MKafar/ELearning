import React, { Component } from 'react';
import { Button, Header, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddGroup.scss';


class ModalAddGroup extends Component {

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
            <Modal closeIcon trigger={<Button primary className='addGroupbutton'>Dodaj grupę</Button>} centered={false}>
                <Modal.Header>Dodaj grupę</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Nazwa grupy</Header>
                        <Input className='groupInput' placeholder='nazwa grupy' onChange={this.handleChange} />
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

export default ModalAddGroup;
