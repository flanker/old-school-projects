#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <sched.h>

//模块
#include "lcd.h"
#include "keyboard.h"
#include "beep.h"

//共享内存
#define BUF_SIZE 1024
#define MY_KEY 24

//游戏状态
#define EXIT 0
#define RUNNING 1
#define GAMEOVER 2
#define PAUSE 3
#define RESTART 4

//贪吃蛇的状态
#define DEAD 0
#define LIVE 1

//进程
int shmid;
pid_t pid;

//一个节点
struct node
{
    int x;
    int y;
};

//游戏结构体
struct snake_ds
{
    struct node nodes[50];      //蛇的节点
    int node_num;               //蛇的节点数
    int direct;     //蛇的方向
    int state;      //游戏状态
    int speed;      //游戏速度
    struct node apple;      //苹果的位置
    struct node todel;      //要清除的节点
}*snake;        //指针

//绘制蛇和苹果
void draw_snake()
{
    int i;
    
    for(i=0; i<snake->node_num; i++)        //遍历每个节点
    {
       draw_box(snake->nodes[i].x, snake->nodes[i].y, GREEN);
    }
    
    draw_box(snake->apple.x, snake->apple.y, RED);
}

//初始化蛇
void init_snake()
{
    int i;
    char c;
    
    //获得共享内存
    if(shmid = shmget(MY_KEY, BUF_SIZE, IPC_CREAT | 0666)==-1)
    {
        printf("shmget error!\n");
        exit(1);
    }
    
    //使用共享内存
    snake = shmat(shmid, 0, 0) ; 

    for(i=0; i<7; i++)      //初始7个节点
    {
        snake->nodes[i].x = 13-i;
        snake->nodes[i].y = 5;
    }
    snake->direct = 1;
    snake->node_num = 7;
    snake->state = RUNNING;
    snake->speed = 100000;
    
    snake->apple.x = 20;
    snake->apple.y = 20;
}

//判断时候吃到苹果
void eatapple()
{
    int i;
    int flag;
    
    if(snake->nodes[0].x == snake->apple.x && snake->nodes[0].y == snake->apple.y)
    {
        snake->node_num++;
        do
        {
            flag=0;
            snake->apple.x=rand()%32;       //产生随机的苹果
            snake->apple.y=rand()%24;
            for(i=0; i<box_num; i++)
            {
                if(snake->apple.x == box[i].x && snake->apple.y == box[i].y)
                    flag=1;
            }
        }while(flag);
        
        beep_on();      //鸣笛
		usleep(100000);
		beep_off();
    }
}

//绘制标题SNAKE
void draw_title()
{
    int i;
    struct node title[]={{5,9},{6,9},{7,9},{4,10},{4,11},{9,11},{10,11},{11,11},{12,11},{15,11},{16,11},{19,11},{22,11},{24,11},{25,11},{26,11},{27,11},{5,12},{6,12},{9,12},{12,12},{14,12},{17,12},{19,12},{21,12},{24,12},{7,13},{9,13},{12,13},{14,13},{17,13},{19,13},{20,13},{24,13},{25,13},{26,13},{27,13},{7,14},{9,14},{12,14},{14,14},{15,14},{16,14},{17,14},{19,14},{21,14},{24,14},{4,15},{5,15},{6,15},{9,15},{12,15},{14,15},{17,15},{19,15},{22,15},{24,15},{25,15},{26,15},{27,15}};
    for(i=0; i<61; i++)
    {
        draw_box(title[i].x, title[i].y, RED);
    }
}

//绘制GAME OVER
void draw_gameover()
{
    int i;
    struct node gameover[]={{6,6},{7,6},{8,6},{9,6},{12,6},{13,6},{16,6},{19,6},{21,6},{22,6},{23,6},{24,6},{6,7},{11,7},{14,7},{16,7},{17,7},{18,7},{19,7},{21,7},{6,8},{8,8},{9,8},{11,8},{12,8},{13,8},{14,8},{16,8},{17,8},{18,8},{19,8},{21,8},{22,8},{23,8},{24,8},{6,9},{9,9},{11,9},{14,9},{16,9},{19,9},{21,9},{6,10},{7,10},{8,10},{9,10},{11,10},{14,10},{16,10},{19,10},{21,10},{22,10},{23,10},{24,10},{6,12},{7,12},{8,12},{9,12},{11,12},{14,12},{16,12},{17,12},{18,12},{19,12},{21,12},{22,12},{23,12},{24,12},{6,13},{9,13},{11,13},{14,13},{16,13},{21,13},{24,13},{6,14},{9,14},{11,14},{14,14},{16,14},{17,14},{18,14},{19,14},{21,14},{22,14},{23,14},{24,14},{6,15},{9,15},{12,15},{13,15},{16,15},{21,15},{23,15},{6,16},{7,16},{8,16},{9,16},{12,16},{13,16},{16,16},{17,16},{18,16},{19,16},{21,16},{24,16}};
    for(i=0; i<61; i++)
    {
        draw_box(title[i].x, title[i].y, RED);
    }
}

//重新开始游戏
void restart()
{
    snake->state == GAMEOVER;
    clear_lcd();
    usleep(3000000);
    draw_gameover();
    usleep(3000000);
    init_lcd();
    clear_lcd();
    draw_title();
    usleep(3000000);
    init_snake();
    clear_lcd();
}

//检查是否碰到自己
int check_self()
{
    int i;
    
    for(i=1; i<snake->node_num; i++)
    {
        if(snake->nodes[0].x == snake->nodes[i].x && snake->nodes[0].y == snake->nodes[i].y)
            return DEAD;
    }
    return LIVE;
}

//检查是否碰到箱子
int check_box()
{
    int i;
    
    for(i=1; i<box_num; i++)
    {
        if(snake->nodes[0].x == box[i].x && snake->nodes[0].y == box[i].y)
            return DEAD;
    }
    return LIVE;
}

//主函数
int main()
{
    char key = NOKEYPRESS;
    int i;
    struct sched_param *param;
    struct node box[]={{6,4},{7,4},{8,4},{23,4},{24,4},{25,4},{6,5},{25,5},{6,6},{25,6},{6,17},{25,17},{6,18},{25,18},{6,19},{7,19},{8,19},{23,19},{24,19},{25,19}};
    int box_num=20;
    
	init_lcd();     //初始化屏幕、绘制屏幕、初始化游戏
    clear_lcd();
    draw_title();
    usleep(3000000);
    init_snake();
    clear_lcd();
    
    if((pid = fork())<0)        //建立子进程
    {
        printf("fork error!\n");
    }
    else if(pid == 0)       //子进程
    {
        sched_setscheduler(pid, SCHED_RR, param);
        
        while(1)
        {
            if(snake->state == PAUSE)
                continue;
            
            if(check_self() == DEAD || check_box() == DEAD)     //判断是否碰到自己或者箱子
            {
                restart();
            }
            
            draw_box(snake->todel.x, snake->todel.y, BLACK);    //绘制蛇
            draw_snake();
            
            eatapple();     //判断是否吃到苹果
            
            //挪动蛇一格
            snake->todel.x=snake->nodes[snake->node_num-1].x;
            snake->todel.y=snake->nodes[snake->node_num-1].y;     

            for(i=snake->node_num-1; i>0; i--)
            {
                snake->nodes[i].x=snake->nodes[i-1].x;
                snake->nodes[i].y=snake->nodes[i-1].y;
            }
            switch(snake->direct)       //蛇头的位置
            {
                case 1:                    
                    if(snake->direct==1 &&snake->nodes[0].x==31)
                        snake->nodes[0].x=0;
                    else
                        snake->nodes[0].x++;
                    break;
                case 2:
                    if(snake->direct==2 &&snake->nodes[0].y==23)
                        snake->nodes[0].y=0;
                    else
                        snake->nodes[0].y++;
                    break;
                case 3:
                    if(snake->direct==3 &&snake->nodes[0].x==0)
                        snake->nodes[0].x=31;
                    else
                        snake->nodes[0].x--;                    
                    break;
                case 4:
                    if(snake->direct==4 &&snake->nodes[0].y==0)
                        snake->nodes[0].y=23;
                    else
                        snake->nodes[0].y--;
                    break;
            }
        
            usleep(snake->speed);       //速度
            
            if(snake->state == EXIT)
                break;
        }
        close_lcd();
    }
    else        //父进程
    {
        sched_setscheduler(pid, SCHED_RR, param);
    
        while(1)
        {
            if(snake->state = GAMEOVER)     //GAMEOVER
            {
                continue;
            }
            key = keyscan(NONBLOCK);        //读取键盘
            if(key == '#')      //游戏暂停
            {
                snake->state = PAUSE;
                continue;
            }
            else if(key !='#' && key!='x')      //暂停恢复
                snake->state = RUNNING;
            if(key == '2' && snake->direct !=2)     //蛇头方向
                snake->direct = 4;
            else if(key == '6' && snake->direct !=3)
                snake->direct = 1;
            else if(key == '5' && snake->direct !=4)
                snake->direct = 2;
            else if(key == '4' && snake->direct !=1)
                snake->direct = 3;
                
            if(key == '*')      //退出游戏
            {
                snake->state = EXIT;    //exit
                break;
            }
                
            usleep(50000);
        }
    }
	return 0;
}
