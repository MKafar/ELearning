import React from 'react'
import { Container, List, Button } from 'semantic-ui-react'

import './DetailList.scss'


const DetailList = (props) => {

    const detailsHandler = () => {
        console.log('Szczegóły', props.id);
    }

    const removeHandler = () => {
        console.log('Usuń', props.id);
    }

    return (
        <div className='detailList'>
            <Container>
                <List divided relaxed>
                    <List.Item>
                        <List.Content floated='right'>
                            <Button onClick={detailsHandler}> Szczegóły </Button>
                            <Button onClick={removeHandler}> Usuń </Button>
                        </List.Content>
                        <List.Content floated='left'>
                            { props.id }
                        </List.Content>
                        <List.Content  floated='left'>
                            { props.date }
                        </List.Content>
                        <List.Content >
                            { props.title }
                        </List.Content>
                        <List.Content floated='left' >
                            { props.variant }
                        </List.Content>
                        <List.Content floated='left'>
                            { props.group }
                        </List.Content>
                    </List.Item>
                </List>
            </Container>

        </div>

    );
}

export default DetailList;