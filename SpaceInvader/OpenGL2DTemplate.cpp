////  Includes
#include <stdio.h>
#include <math.h>
#include <random>
#include <glut.h>
#include <list>
#include <iostream>

using namespace std;

void Display(void);
void Anim(void);
void Timer(int value);

void specialKey(int key, int x, int y);
void Space(unsigned char key, int x, int y);


bool EnemyDireLeft = true;
bool fire = false;
struct bullets {
	float x;
	float y;

	bool operator == (const bullets& other) const {
		return x == other.x && y == other.y;
	}
};
struct powerUps {
	float x;
	float y;

	bool operator == (const powerUps& other) const {
		return x == other.x && y == other.y;
	}
}; 

list < bullets> bulletsPlayer ;
list < bullets> bulletsEnemy;
list <powerUps> avaliablePowerups;
float inGame = true; 


struct Player {
	int lives;
	list <powerUps>  powerups;
	float PlayerX;
	float PlayerY;
	int score;
	bool poweredUp =false;
	float Rcolor = 1;
	float Gcolor = 0;
};
struct Enemy {
	int health;
	float Enemyx;
	bool EnemyDireLeft;
};
Player * player =new Player();
Enemy * enemy = new Enemy();
bool PlayerHit(bullets a);
bool EnemyHit(bullets a);
bool PoweredUp(powerUps p);
bool StartGame = true;


void main(int argc, char** argr)
{
	enemy->Enemyx = 0;
	enemy->EnemyDireLeft = true;
	player->PlayerX =0 ;
	player->PlayerY = 0;
	player->score = 0;
	player->lives = 3;
	enemy->health = 100;
	glutInit(&argc, argr);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(1140, 650);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Space Invader");
	glutDisplayFunc(Display);
	glutIdleFunc(Anim);
	glLineWidth(5.0);
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
	gluOrtho2D(-50.0, 1090, -2, 650);
	glutSpecialFunc(specialKey);
	glutKeyboardFunc(Space);
	glutTimerFunc(1*1000, Timer, 0);
	glutTimerFunc(20*1000, Timer, 2);
	
	glutMainLoop();

}
void Space(unsigned char key, int x, int y) {
	if (key == 32 && inGame) {
	    bullets b;
		b.x = player->PlayerX;
		b.y = player->PlayerY;
		bulletsPlayer.push_back(b);
	}
	else if (key == 32 && !inGame) {
		list <bullets> temp4;
		list <powerUps> temp3;
		player->lives = 3;
		player->PlayerX = 0;
		player->PlayerY = 0;
		player->poweredUp = false;
		player->score = 0;
		player->powerups = temp3;
		player->Rcolor = 1;
		player->Gcolor = 0;
		enemy->EnemyDireLeft = true;
		enemy->Enemyx = 0;
		enemy->health = 100;
		bulletsPlayer = temp4;
		bulletsEnemy= temp4;
		avaliablePowerups=temp3;
		inGame = true;
		EnemyDireLeft = true;
		fire = false;
	
	}
	else if (key == 27) {
		exit(0);
	}
	glutPostRedisplay();
}

void specialKey(int key, int x, int y) {
	switch (key)
	{

	case GLUT_KEY_LEFT:
		if(player->PlayerX>=-458)
		player->PlayerX-=5;
		break;
	case GLUT_KEY_RIGHT:
		if(player->PlayerX<=458)
		player->PlayerX+=5;
		break;
	case GLUT_KEY_UP:
		if (player->PlayerY <= 320)
			player->PlayerY += 5;
		break;
	case GLUT_KEY_DOWN:
		if (player->PlayerY >= 0)
			player->PlayerY -= 5;
		break;
	}
	
	glutPostRedisplay();
}

void Anim() {
	list <bullets> temp3;
	for (bullets b: bulletsEnemy) {
		bool playerHit = PlayerHit(b);
		if (playerHit && !player->poweredUp) {
			player->lives -= 1;
		}
		else if (playerHit && player->poweredUp) {
		}
		else {
			bullets a;
			a.x = b.x;
			a.y = b.y + 1.9;
			if (a.y >= 0) temp3.push_back(a);
		}
	}
	bulletsEnemy = temp3;

	list <bullets> temp4;
	for (bullets a : bulletsPlayer) {
		bool enemyHit = EnemyHit(a);
		if (enemyHit) {
			enemy->health -= 10;
			player->score += 10;
		}
		else {
			bullets b;
			b.x = a.x;
			b.y = a.y + 2;
			if (b.y <= 650) temp4.push_back(b);
		}
	}
	bulletsPlayer = temp4;

	list <powerUps> temp5;
	for (powerUps p : avaliablePowerups) {
		bool powered = PoweredUp(p);
		if (powered) {
			player->powerups.push_back(p);
			player->poweredUp = true;
			player->Rcolor = 0;
			player->Gcolor = 1;
			glutTimerFunc(10* 1000, Timer, 4);
		}
		else
			temp5.push_back(p);
	}
	avaliablePowerups = temp5;

	if (enemy->Enemyx <= -404)  enemy->EnemyDireLeft = false;
	else if (enemy->Enemyx >= 404) enemy->EnemyDireLeft = true;
	if (enemy->EnemyDireLeft) {
		enemy->Enemyx = enemy->Enemyx -0.2;
	}
	else enemy->Enemyx = enemy->Enemyx + 0.2;

	if (player->lives == 0 || enemy->health == 0) {
		inGame = false;
	}

	glutPostRedisplay();
}

void Timer(int value) {
	if (value == 0) {
		bullets b;
		b.x = enemy->Enemyx;
		b.y = 0;
		bulletsEnemy.push_back(b);
		glutPostRedisplay();
		glutTimerFunc(1 * 1000, Timer, 1);
	}
	if (value == 1) {
		bullets b;
		b.x = enemy->Enemyx;
		b.y = 0;
		bulletsEnemy.push_back(b);
		glutPostRedisplay();
		glutTimerFunc(5 * 1000, Timer, 0);
	}
	if (value == 2) 
	{
		powerUps a;
		if (avaliablePowerups.size() < 2 && ! player->poweredUp) {
			if(avaliablePowerups.size()!=0)
				a = avaliablePowerups.front();
			else {
				a.x = 0;
				a.y = 0;
			}
			while (true) {
				float y = rand() % 251 + 150;
				float x = rand() % 700 + 100;
				if (x - a.x >= 200 || x - a.x <= -200) {
					powerUps p;
					p.x = x;
					p.y = y;
					avaliablePowerups.push_back(p);
					break;
				}

			}
		}
		int time = rand() % 41 + 20;
		glutTimerFunc(time * 1000, Timer, 2);
		cout << time;

	}
	if (value == 4 && player->poweredUp) {
		player->powerups.pop_front();
		if (player->powerups.size() == 0) {
			player->Rcolor = 1;
			player->Gcolor = 0;
			player->poweredUp = false;
		}

	}

}
void createBoundaries() {
	glPushMatrix();
	glTranslated(1000, 0, 0);
	glBegin(GL_QUADS);
	glColor3f(1, 1, 1);
	glVertex3f(0, 650, 0);
	glVertex3f(90,650, 0);
	glVertex3f(90, 0, 0);
	glVertex3f(0, 0, 0);
	glEnd();
	glPopMatrix();
	glBegin(GL_QUADS);
	glVertex3f(-50, 650, 0);
	glVertex3f(0, 650, 0);
	glVertex3f(0, 0, 0);
	glVertex3f(-50, 0, 0);
	glEnd();

}

void createBulletsPlayer(){
	for (const bullets a : bulletsPlayer) {
		glPushMatrix();
		glColor3f(0.5, 0.9, 1.0);
		glTranslatef(500 + a.x, 80+a.y, 0);
		GLUquadric* quadObj = gluNewQuadric();
		gluDisk(quadObj, 0, 5, 50, 50);
		glPopMatrix();
	}
}
bool EnemyHit(bullets b) {
	//404+enemy->Enemyx, 500
	float bcx = 500 + b.x;
	float bcy = 80 + b.y;
	float xmin = 404 + enemy->Enemyx;
	float xmid = 96 + 404 + enemy->Enemyx;
	float xmax = 192 + 404 + enemy->Enemyx;
	float ymin = (12 + 500);
	float ymid = (96 + 500);
	float gradL = (ymin - ymid) / (xmid - xmin);
	float interceptL = ymin - gradL *(xmid);
	float gradR = (ymin - ymid) / (xmid - xmax);
	float interceptR = ymin - gradR * xmid;
	float Yleft = gradL * bcx + interceptL;
	float Yright = gradR * bcx + interceptR;
	if (bcx >= xmin && bcx <= xmid && bcy >= Yleft) {
		return true;
	}
	else if (bcx >= xmid && bcx <= xmax && bcy >= Yright) {
		return true;
	}
	else if (bcx >= 48 + 404 + enemy->Enemyx && bcx <= 60 + 404 + enemy->Enemyx && bcy >= 500) {
		return true;
	}
	else if (bcx >= 132 + 404 + enemy->Enemyx && bcx <= 144 + 404 + enemy->Enemyx && bcy >= 500) {
		return true;
	}
	else if ((bcx == xmid && bcy >= ymin )|| (bcx == xmin && bcy>=ymid) || (bcx==xmax && bcy>=ymid))
		return true;
	return false;
}
bool PlayerHit(bullets b) {
	float planeTipX = 35 + 465 + player->PlayerX;
	float planeTipY = 84 + 20 + player->PlayerY;
	float planeLTipX = 28 + 465 + player->PlayerX;
	float planeLTipy = 70 + 20 + player->PlayerY;;
	float planeRTipX = 42 + 465 + player->PlayerX;
	float planeRTipy = 70 + 20 + player->PlayerY;;
	float PlaneYMin = 20 + player->PlayerY;
	float playerXMin = 465 + player->PlayerX;
	float wingYMin = 35+ 20 + player->PlayerY;
	float wingYMax = 56 + 20 + player->PlayerY;
	float gradientLeft = (planeTipY - planeLTipy) / (planeTipX - planeLTipX);
	float interceptLeft = planeLTipy - gradientLeft * planeLTipX;
	float gradientRight = (planeTipY - planeLTipy) / (planeTipX - planeRTipX);
	float interceptRight = planeLTipy - gradientRight * planeRTipX;
	bool f = false;
	float bcx = (500 + b.x);
	float bcy = ( 510 - b.y);
	float Yleft = gradientLeft *bcx + interceptLeft;
	float YRight = gradientRight * bcx + interceptRight;
	if (bcx == planeTipX && bcy == planeTipY)
		f = true;
	else if (bcx >= planeLTipX && bcx <= planeRTipX && bcy >= PlaneYMin && bcy <= planeLTipy) {
		f = true;
		
	}
	else if (bcx >= playerXMin && bcx <= planeLTipX && bcy >= wingYMin && bcy <= wingYMax) {
		f = true;
		
	}
	else if (bcx >= planeRTipX && bcx <= 70 + 465 + player->PlayerX && bcy >= wingYMin && bcy <= wingYMax) {
		f = true;
	
	}
	else if (bcy<= Yleft && bcx>= planeTipX &&bcx<= planeLTipX) {
		f = true;
	
	}
	else if (bcy <= YRight && bcx >= planeRTipX && bcx <= planeTipX) {
		f = true;
	
	}
	return f;

		
}
 bool PoweredUp(powerUps p) {
	float ptip1x = 0 + p.x - 14;
	float ptip2x = 14 + p.x - 14;
	float ptip3x = 28 + p.x - 14;
	float ptip1y = 14 + p.y - 14;
	float ptip2y = 28 + p.y - 14;
	float ptip3y = 0 + p.y - 14;
	float g1NEG = ((ptip2y - ptip1y) / (ptip2x - ptip3x));
	float g2POS = ((ptip2y - ptip1y) / (ptip2x - ptip1x));
	float intc1L = ptip2y - g2POS * ptip2x;
	float intc2L = ptip1y - g1NEG* ptip1x;
	float intc1R = ptip2y - g1NEG * ptip2x;
	float intc2R = ptip2y - g2POS * ptip2x;
	float planeTipX = 35 + 465 + player->PlayerX;
	float planeTipY = 84 + 20 + player->PlayerY;
	float planeLTipX = 28 + 465 + player->PlayerX;
	float planeLTipy = 70 + 20 + player->PlayerY;;
	float planeRTipX = 42 + 465 + player->PlayerX;
	float planeRTipy = 70 + 20 + player->PlayerY;;
	float PlaneYMin = 20 + player->PlayerY;
	float playerXMin = 465 + player->PlayerX;
	float wingYMin = 35 + 20 + player->PlayerY;
	float wingYMax = 56 + 20 + player->PlayerY;
	float gradientLeft = (planeTipY - planeLTipy) / (planeTipX - planeLTipX);
	float interceptLeft = planeLTipy - gradientLeft * planeLTipX;
	float gradientRight = (planeTipY - planeLTipy) / (planeTipX - planeRTipX);
	float interceptRight = planeLTipy - gradientRight * planeRTipX;
	float wingBy = 7+ 20 + player->PlayerY;
	float wingBX1=14+ 465 + player->PlayerX;
	float wingBX2 = 56+ 465 + player->PlayerX;
	//ttip
	if (planeTipX * g1NEG + intc1R == planeTipY && planeTipX >= ptip2x && planeTipX <= ptip3x)
		return true;
	else if (planeTipX * g1NEG + intc2L == planeTipY && planeTipX >= ptip1x && planeTipX <= ptip2x)
		return true;
	else if (planeTipX * g2POS + intc1L == planeTipY && planeTipX >= ptip2x && planeTipX <= ptip3x)
		return true;
	else if (planeTipX * g2POS + intc2R == planeTipY && planeTipX >= ptip1x && planeTipX <= ptip2x)
		return true;

	//ltip
	else if (planeLTipX * g1NEG + intc1R <= planeRTipy && planeLTipX * g1NEG + intc2L >= PlaneYMin
		&& planeLTipX >= ptip2x && planeLTipX <= ptip3x)
		return true;
	else if (planeLTipX * g1NEG + intc2L <= planeRTipy && planeLTipX * g1NEG + intc2L >= PlaneYMin
		&& planeLTipX >= ptip1x && planeLTipX <= ptip2x)
		return true;
	else if (planeLTipX * g2POS + intc1L <= planeRTipy && planeLTipX * g1NEG + intc2L >= PlaneYMin
		&& planeLTipX >= ptip2x && planeLTipX <= ptip3x)
		return true;
	else if (planeLTipX * g2POS + intc2R <= planeRTipy && planeLTipX * g1NEG + intc2L >= PlaneYMin
		&& planeLTipX >= ptip1x && planeLTipX <= ptip2x)
		return true;

	//rtip
	else if (planeRTipX * g1NEG + intc1R <= planeRTipy && planeRTipX * g1NEG + intc1R >= PlaneYMin
		&& planeRTipX >= ptip2x && planeRTipX <= ptip3x)
		return true;
	else if (planeRTipX * g1NEG + intc2L <= planeRTipy && planeRTipX * g1NEG + intc2L >= PlaneYMin
		&& planeRTipX >= ptip1x && planeRTipX <= ptip2x)
		return true;
	else if (planeRTipX * g2POS + intc1L <= planeRTipy && planeRTipX * g1NEG + intc2L >= PlaneYMin
		&& planeRTipX >= ptip2x && planeRTipX <= ptip3x)
		return true;
	else if (planeRTipX * g2POS + intc2R <= planeRTipy && planeRTipX * g1NEG + intc2L >= PlaneYMin
		&& planeRTipX >= ptip1x && planeRTipX <= ptip2x)
		return true;

	//bottom 

	else if ((ptip1y == PlaneYMin && ptip1x >= planeLTipX && ptip1x <= planeRTipX)
		|| (ptip2y == PlaneYMin && ptip2x >= planeLTipX && ptip2x <= planeRTipX)
		|| (ptip3y == PlaneYMin && ptip2x >= planeLTipX && ptip2x <= planeRTipX)
		|| (ptip1y == PlaneYMin && ptip3x >= planeLTipX && ptip3x <= planeRTipX)) {

		return true;
	}

	
	return false;

}
void createBulletsEnemy() {
	for (const bullets a : bulletsEnemy) {
		glPushMatrix();
		glColor3f(1.0, 1.0, 0.0);
		glTranslatef(500 + a.x, 510 - a.y, 0);
		GLUquadric* quadObj = gluNewQuadric();
		gluDisk(quadObj, 0, 5, 50, 50);
		glPopMatrix();
	} 
}
void createPowerUps() {
	for (const powerUps p : avaliablePowerups) {
		glPushMatrix();
		glTranslated(p.x - 14, p.y- 14, 0);
		glScaled(7, 7, 0);
		glColor3f(0, 1, 0);
		glBegin(GL_QUADS);
		glVertex3f(0, 2, 0);
		glVertex3f(2, 4, 0);
		glVertex3f(4, 2, 0);
		glVertex3f(2, 0, 0);
		glEnd();
		glPopMatrix();
	}
}

void CreatePlayer() {
	glPushMatrix();
	glTranslated(465+player->PlayerX, 20+ player->PlayerY, 0);
	glScaled(7, 7, 0);
	glColor3f(player->Rcolor, player->Gcolor, 0.0f);
	//plane body
	glBegin(GL_POLYGON);
	glVertex3f(4.0f, 0.0f, 0.0f);
	glVertex3f(6.0f, 0.0f, 0.0f);
	glVertex3f(6.0f, 10.0f, 0.0f);
	glVertex3f(5.0f, 12.0f, 0.0f);
	glVertex3f(4.0f, 10.0f, 0.0f);
	glEnd();

	glBegin(GL_QUADS);
	//plane bullets


	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(0.2f, 5.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.2f, 7.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(1.0f, 7.0f, 0.0f);
	glVertex3f(1.0f, 5.5f, 0.0f);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(2.0f, 6.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(2.0f, 8.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(2.8f, 8.0f, 0.0f);
	glVertex3f(2.8f, 7.0f, 0.0f);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(9.8f, 5.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(9.8f, 7.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(9.0f, 7.0f, 0.0f);
	glVertex3f(9.0f, 5.5f, 0.0f);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(7.8f, 6.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(7.8f, 8.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(7.0f, 8.0f, 0.0f);
	glVertex3f(7.0f, 7.0f, 0.0f);

	glEnd();

	glBegin(GL_TRIANGLES);
	glColor3f(player->Rcolor, player->Gcolor, 0.0f);
	//top wings
	glVertex3f(0.0f, 5.0f, 0.0f);
	glVertex3f(4.0f, 6.0f, 0.0f);
	glVertex3f(4.0f, 8.0f, 0.0f);

	glVertex3f(10.0f, 5.0f, 0.0f);
	glVertex3f(6.0f, 6.0f, 0.0f);
	glVertex3f(6.0f, 8.0f, 0.0f);

	//bottom wings
	glVertex3f(2.0f, 1.0f, 0.0f);
	glVertex3f(4.0f, 1.0f, 0.0f);
	glVertex3f(4.0f, 2.0f, 0.0f);

	glVertex3f(8.0f, 1.0f, 0.0f);
	glVertex3f(6.0f, 1.0f, 0.0f);
	glVertex3f(6.0f, 2.0f, 0.0f);
	glEnd();

	glBegin(GL_QUADS);
	//plane thruster
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(3.5f, 0.0f, 0.0f);
	glVertex3f(4.5f, 0.0f, 0.0f);
	glColor3f(0.0f, 0.0f, 0.0f);
	glVertex3f(4.5f, 7.0f, 0.0f);
	glVertex3f(3.5f, 7.0f, 0.0f);

	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(5.5f, 0.0f, 0.0f);
	glVertex3f(6.5f, 0.0f, 0.0f);
	glColor3f(0.0f, 0.0f, 0.0f);
	glVertex3f(6.5f, 7.0f, 0.0f);
	glVertex3f(5.5f, 7.0f, 0.0f);
	glEnd();


	glPopMatrix();
}

void CreateEnemy() {
	glPushMatrix();
	glTranslated(404+enemy->Enemyx, 500, 0);
	glScaled(12, 12, 0);
	glBegin(GL_LINES);
	glColor3f(1.0, 1.0, 1.0);
	glVertex3f(5.0f, 9.0f, 0.0f);
	glColor3f(0.5, 0.5, 0.5);
	glVertex3f(8.0f, 11.0f, 0.0f);


	glVertex3f(8.0f, 11.0f, 0.0f);
	glColor3f(1.0, 1.0, 1.0);
	glVertex3f(11.0f, 9.0f, 0.0f);
	glEnd();

	glBegin(GL_QUADS);
	glColor3f(1.0, 0.0, 0.0);
	glVertex3f(5.0f, 8.0f, 0.0f);
	glVertex3f(8.0f, 10.0f, 0.0f);
	glVertex3f(8.0f, 10.0f, 0.0f);
	glVertex3f(11.0f, 8.0f, 0.0f);

	glVertex3f(4.0f, 0.0f, 0.0f);
	glVertex3f(5.0f, 1.0f, 0.0f);
	glVertex3f(5.0f, 4.0f, 0.0f);
	glVertex3f(4.0f, 5.0f, 0.0f);

	glVertex3f(12.0f, 0.0f, 0.0f);
	glVertex3f(11.0f, 1.0f, 0.0f);
	glVertex3f(11.0f, 4.0f, 0.0f);
	glVertex3f(12.0f, 5.0f, 0.0f);

    glEnd();

	glBegin(GL_TRIANGLE_FAN);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(8.0f, 1.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.0f, 8.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(3.0f, 10.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(8.0f, 8.0f, 0.0f);
	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex3f(13.0f, 10.0f, 0.0f);
	glColor3f(0.5f, 0.5f, 0.5f);
	glVertex3f(16.0f, 8.0f, 0.0f);
	glEnd();

	//health


	

	glPopMatrix();
}

void print(int x, int y, char* string)
{
	int len, i;

	//set the position of the text in the window using the x and y coordinates
	glRasterPos2f(x, y);

	//get the length of the string to display
	len = (int)strlen(string);

	//loop to display character by character
	for (i = 0; i < len; i++)
	{
		glutBitmapCharacter(GLUT_BITMAP_9_BY_15, string[i]);
	}
}
void print2(int x, int y, char* string)
{
	int len, i;

	//set the position of the text in the window using the x and y coordinates
	glRasterPos2f(x, y);

	//get the length of the string to display
	len = (int)strlen(string);

	//loop to display character by character
	for (i = 0; i < len; i++)
	{
		glutBitmapCharacter(GLUT_BITMAP_HELVETICA_12, string[i]);
	}
}
void printGameOver(int x, int y, char* string)
{
	int len, i;

	//set the position of the text in the window using the x and y coordinates
	glRasterPos2f(x, y);

	//get the length of the string to display
	len = (int)strlen(string);

	//loop to display character by character
	for (i = 0; i < len; i++)
	{
		glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, string[i]);
	}
}
void createLives() {
	int x = 0;
	for (int i = 0;i < player->lives;i++) {
		glPushMatrix();
		glTranslated(1014+x, 70, 0);
		glScaled(8, 8, 0);
		glColor3ub(255, 0, 0);  // Color Red
		glBegin(GL_POLYGON);
		for (float x = -1.139; x <= 1.139; x += 0.003)
		{
			float delta = cbrt(x * x) * cbrt(x * x) - 4 * x * x + 4;
			float y1 = (cbrt(x * x) + sqrt(delta)) / 2;
			float y2 = (cbrt(x * x) - sqrt(delta)) / 2;
			glVertex2f(x, y1);
			glVertex2f(x, y2);
		}
		glEnd();
		glPopMatrix();
		x += 25;
	}
	


}
void createHealth() {
	glPushMatrix();
	glTranslated(1005, 552, 0);
	glBegin(GL_LINE_LOOP);
	glPointSize(10);
	glColor3f(0, 0, 0);
	glVertex3f(0, 0, 0);
	glVertex3f(0, 10, 0);
	glVertex3f(50, 10, 0);
	glVertex3f(50, 0, 0);
	glEnd();
	glPopMatrix();
	glPushMatrix();
	glTranslated(1005, 552, 0);
	glBegin(GL_QUADS);
	glPointSize(10);
	glColor3f(1, 0, 0);
	glVertex3f(0, 0, 0);
	glVertex3f(0, 10, 0);
	glVertex3f((50*enemy->health)/100, 10, 0);
	glVertex3f((50 * enemy->health) / 100, 0, 0);
	glEnd();
	glPopMatrix();

	
}


void Display(void) {
	glClear(GL_COLOR_BUFFER_BIT);
	 if (inGame) {
		CreatePlayer();
		CreateEnemy();
		createBulletsPlayer();
		createBulletsEnemy();
		createPowerUps();
		createBoundaries();
		char* p0s[20];
		char* p1s[20];
		sprintf((char*)p0s, "Score: %d", player->score);
		sprintf((char*)p1s, "%d", enemy->health);
		glPushAttrib(GL_CURRENT_BIT);
		glColor3f(0, 0, 0);
		print(1005, 325, (char*)p0s);
		print(1005, 100, "My Lives:");
		print(1005, 600, "Enemy's");
		print(1005, 580, "Health:");
		glPopAttrib();
		createLives();
		createHealth();
		glPushAttrib(GL_CURRENT_BIT);
		glColor3f(0, 0, 0);
		print2(1059, 553, (char*)p1s);
		print2(1079, 553, "%");
		glPopAttrib();
	}
	else if(!inGame && player->lives==0) {
		char* p1s[20];
		sprintf((char*)p1s, "You Score is %d", player->score);
		glPushAttrib(GL_CURRENT_BIT);
		glColor3f(1, 0, 0);
		printGameOver(450, 326, "GameOver");
		printGameOver(440, 270, (char*)p1s);
		printGameOver(400, 200, "To Play Again Press Enter");
		glPopAttrib();
	}
	else if (!inGame && enemy->health == 0){
			glPushAttrib(GL_CURRENT_BIT);
		glColor3f(1, 0, 0);
		printGameOver(400, 400, "Congaratulations");
		printGameOver(425, 350, "You Won !!!");
		printGameOver(360, 300, "To Play Again Press Enter");
		glPopAttrib();
	}
	glFlush();
}

