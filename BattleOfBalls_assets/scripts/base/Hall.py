# -*- coding: utf-8 -*-
import Functor
import KBEngine
from KBEDebug import *

class Hall(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		KBEngine.globalData["Hall"]=self 
		self.matchIndiviQueue=[]						#匹配队列
		self.matchBattleQueue=[]						#匹配队列
		self.matchTeamQueue=[]							#匹配队列
		self.playerRoomEntity={}						#房间实体

		self.addTimer(4,0.5,4)							#匹配定时器

	#匹配个人模式
	def matchIndiviGame(self,entityCall):
		if entityCall not in self.matchIndiviQueue:
			self.matchIndiviQueue.append(entityCall)

	#匹配大逃杀模式
	def matchBattleGame(self,entityCall):
		if entityCall not in self.matchBattleQueue:
			self.matchBattleQueue.append(entityCall)

	#匹配团队模式
	def matchTeamGame(self,entityCall):
		if entityCall not in self.matchTeamQueue:
			self.matchTeamQueue.append(entityCall)

	#分配房间
	def assignPlayerRoom(self):
		roomNum=len(self.matchIndiviQueue)//2
		self.createPlayerRoom(roomNum,0)

		roomNum=len(self.matchBattleQueue)%100
		self.createPlayerRoom(roomNum,1)

		roomNum=len(self.matchTeamQueue)%10
		self.createPlayerRoom(roomNum,2)

	#创建房间
	def createPlayerRoom(self,roomNum,type):
		playerList=[]
		if type==0:
			for room in range(roomNum):
				for i in range(2):
					playerList.append(self.matchIndiviQueue.pop(0))

		if type==1:
			for room in range(roomNum):
				for i in range(100):
					playerList.append(self.matchBattleQueue.pop(0))

		if type==2:
			for room in range(roomNum):
				for i in range(10):
					playerList.append(self.matchTeamQueue.pop(0))

		if len(playerList)==0:
			return
		print("match game successfully!")
		#创建房间ID,并检测是否重复
		roomID=KBEngine.genUUID64()
		while roomID in self.playerRoomEntity:
			roomID=KBEngine.genUUID64()

		#创建房间实体
		KBEngine.createEntityAnywhere("Room",{"roomID":roomID,"roomType":type,"playerList":playerList},Functor.Functor(self.createPlayerRoomCB,roomID))

	#创建房间回调函数
	def createPlayerRoomCB(self,roomID,entityCall):
		self.playerRoomEntity[roomID]=entityCall
		DEBUG_MSG("Halls::onRoomCreatedCB: space %i. entityID=%i" % (roomID, entityCall.id))

	#定时器：分配房间
	def onTimer(self, id, userArg):
		if userArg==4:
			self.assignPlayerRoom()
		