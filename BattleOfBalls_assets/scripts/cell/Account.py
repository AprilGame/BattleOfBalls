# -*- coding: utf-8 -*-
import Math
import random
import KBEngine
from KBEDebug import *

MAX_MAP_SIZE=100
STATE_TIMER=5
ADDTRAP_TIMER=8
WAITING_TIMER=9

class Account(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		self.controllerID=0
		self.position=(0.0,0.0,0.0)
		self.setViewRadius(30,1.0)
		self.addTimer(5,0,ADDTRAP_TIMER)
		DEBUG_MSG("Account cell space id: %i" % (self.spaceID))

	#吃掉食物，增加体重
	def addPlayerMass(self,mass):
		self.playerMass+=mass
		#self.playerLayer=self.playerMass//100+1
		#self.playerSpeed=8-self.playerMass*0.01
		#self.playerScale=self.playerMass/100+1
		self.updateProximity(self.playerScale)
		#更新球的半斤大小
		#更新球的移动速度
		#更新球的碰撞范围

	#其它实体进入触发范围
	def onEnterTrap(self,entity,rangeXZ,rangeY,controller,userArg):
	
		#食物实体
		if entity.returnType()==1:
			self.addPlayerMass(entity.foodMass)
			#entity.destroy()

		
		#破碎球
		elif entity.returnType()==2:
			x=entity.position.x
			z=entity.position.z
			entity.destroy()
			self.client.playerDead(self)
			self.waitResurrection()
			KBEngine.globalData["Room_%i" % self.spaceID].createFoodShatter(self.playerMass,x,z)
			#产生碎片

		
		
		else:
			if self.playerMass>entity.playerMass*1.2 and entity.playerState==0:
				self.addPlayerMass(enttiy)
				entity.waitResurrection()
			elif self.playerMass<entity.playerMass*1.2 and self.playerState==0:
				self.allClients.playerDead(self)
				self.waitResurrection()
		
		
		
	#随机坐标
	def createPosition3D(self):
		return Math.Vector3(random.randint(0, MAX_MAP_SIZE), 0.0, random.randint(0, MAX_MAP_SIZE))

	def onGetCell(self):
		print("create cell successfully!")

	def onGetWitness(self):
		"""
		KBEngine method.
		绑定了一个观察者(客户端)
		"""
		DEBUG_MSG("Account::onGetWitness: %i." % self.id)

	#定时器回调：创建trap
	def onTimer(self,id,userArg):
		if userArg==ADDTRAP_TIMER:
			self.playerState=0
			self.controllerID=self.addProximity(1,0,0)
			self.delTimer(id)
		elif userArg==WAITING_TIMER:
			self.allClients.playerAlive(self)
			self.delTimer(id)
			self.addTimer(5,0,STATE_TIMER)

		elif userArg==STATE_TIMER:
			self.playerState=0
			self.delTimer(id)



	#已经复活，告诉客户端
	def waitResurrection(self):
		self.playerMass=1
		self.playerLayer=1
		self.playerSpeed=2.0
		self.playerScale=1.0
		self.playerState=1
		self.addTimer(5,0,WAITING_TIMER)


	#返回实体类型
	def returnType(self):
		return 0

	#更新玩家状态：0：正常状态 1：无敌状态
	def updatePlayerState(self,state):
		self.playerState=state

	#更新触发范围
	def updateProximity(self,scale):
		self.cancelController(self.controllerID)
		self.controllerID=self.addProximity(1,0,0)


